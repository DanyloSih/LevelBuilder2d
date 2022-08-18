using System.Collections.Generic;
using System.Collections.ObjectModel;
using LevelBuilder2d.Building;
using LevelBuilder2d.Controls;
using LevelBuilder2d.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Zenject;

namespace LevelBuilder2d.Selection
{
	public class FiguresSelector : MonoBehaviour, IFiguresSelector, IStopable
	{
		[SerializeField] private float _minSelectBoxDistance = 5f;

		private List<IFigure> _selectedFigures = new List<IFigure>();
		private MainControls _mainControls;
		private OverUITester _overUITester;
		private ICameraRayThrower _cameraRayThrower;
		private ISelectionArea _selectionArea;
		private IContainer<IFigure> _figuresContainer;
		private Vector2 _startSelectionPoint;
		private bool _isSelectionStart = false;

		public Rect SelectionRect { get; private set; }

		public event UnityAction<IFiguresSelector> SelectionChanged;

		[Inject]
		public void Construct(
			ICameraRayThrower cameraRayThrower,
			ISelectionArea selectionArea,
			IContainer<IFigure> figuresContainer)
		{
			_cameraRayThrower = cameraRayThrower;
			_selectionArea = selectionArea;
			_figuresContainer = figuresContainer;
        }

		protected void Awake()
		{
			_mainControls = new MainControls();
			_mainControls.FigureSelector.StartSelection.performed += OnSelectionStart;
			_mainControls.FigureSelector.StopSelection.performed += OnSelectionStop;
			_mainControls.FigureSelector.SelectionPointerMove.performed += OnSelectionPointerMove;
            _selectionArea.Disable();

			_overUITester = new OverUITester(LayerMask.NameToLayer("UI"));
        }

		protected void OnEnable()
		{
			_mainControls.Enable();
		}

		protected void OnDisable()
		{
			if (!gameObject.scene.isLoaded)
				return;

			_mainControls.Disable();
            _selectionArea.Disable();
        }

        public void Stop()
			=> enabled = false;

		public void Resume()
			=> enabled = true;

        public ReadOnlyCollection<IFigure> GetSelectedFigures()
        {
            IFigure[] copy = new IFigure[_selectedFigures.Count];
            _selectedFigures.CopyTo(copy, 0);
            return new ReadOnlyCollection<IFigure>(copy);
        }

        private Vector2 GetSelectionPointerPosition()
			=> _mainControls.FigureSelector.SelectionPointerMove.ReadValue<Vector2>();

        private void OnSelectedFigureDestroyed(IDestroyable selectedFigure)
			=> UnsubscribeFromSelectedFigure(selectedFigure);

        private void OnSelectedFigureUnselected(ISelectable selectedFigure)
			=> UnsubscribeFromSelectedFigure(selectedFigure);

        private void SubscribeOnSelectedFigure(IFigure figure)
        {
			if (_selectedFigures.Contains(figure))
				return;

            figure.Destroyed += OnSelectedFigureDestroyed;
            figure.Unselected += OnSelectedFigureUnselected;
            _selectedFigures.Add(figure);
            figure.Select();
			UpdateSelectionRect();
            SelectionChanged?.Invoke(this);
        }

        private void UnsubscribeFromSelectedFigure(object selectedFigure) 
		{
			IFigure figure = (IFigure)selectedFigure;
			figure.Destroyed -= OnSelectedFigureDestroyed;
			figure.Unselected -= OnSelectedFigureUnselected;
			_selectedFigures.Remove(figure);
			UpdateSelectionRect();
            SelectionChanged?.Invoke(this);
        }

        private void OnSelectionStart(InputAction.CallbackContext obj)
		{
			if (_overUITester.IsPointerOverUIElement(GetSelectionPointerPosition()))
				return;

			_isSelectionStart = true;
			_startSelectionPoint = GetSelectionPointerPosition();
		}

		private void SelectFigureByRay()
		{
			RaycastHit2D hit = _cameraRayThrower.Throw();

			if (hit.collider == null)
				return;

			Component component = hit.collider.GetComponent(typeof(ISelectable));

			if (component == null)
				return;

			IFigure figure = (IFigure)component;
			SubscribeOnSelectedFigure(figure);
		}

		private void OnSelectionStop(InputAction.CallbackContext obj)
        {
            if (enabled == false 
			|| !_isSelectionStart)
                return;

            _isSelectionStart = false;
           
			SelectFiguresInBounds();
			_selectionArea.UpdateRect(Vector2.zero, Vector2.zero);
            _selectionArea.Disable();

            SelectFigureByRay();
        }

        private void OnSelectionPointerMove(InputAction.CallbackContext obj)
        {
			float pointerDistanceFromStart
				= Vector2.Distance(_startSelectionPoint, GetSelectionPointerPosition());

            if (_isSelectionStart
			&& pointerDistanceFromStart > _minSelectBoxDistance)
			{
                _selectionArea.Enable();
				_selectionArea.UpdateRect(_startSelectionPoint, GetSelectionPointerPosition());
            }
        }

		private void SelectFiguresInBounds()
		{
			foreach (var item in _figuresContainer.GetObjects())
			{
				if (_selectionArea.IsContain(item))
				{
					SubscribeOnSelectedFigure(item);
					item.Select();
				}
			}
        }

		private void UpdateSelectionRect() 
		{    
            if (_selectedFigures.Count == 0)
                SelectionRect = new Rect();
            else
                SelectionRect = GetSelectionRect(_selectedFigures, _selectedFigures[0].Position);
        }

        private Rect GetSelectionRect(
            List<IFigure> selectedFigures,
            Vector2 firstFigurePosition)
        {
            Vector3 min = firstFigurePosition;
            Vector3 max = firstFigurePosition;

            for (int i = 1; i < selectedFigures.Count; i++)
            {
                if (selectedFigures[i] == null)
                    continue;

                Vector2 pos = selectedFigures[i].Position;
                min.x = Mathf.Min(pos.x, min.x);
                max.x = Mathf.Max(pos.x, max.x);
                min.y = Mathf.Min(pos.y, min.y);
                max.y = Mathf.Max(pos.y, max.y);
            }
            Rect selectionRect = new Rect();
            selectionRect.min = min;
            selectionRect.max = max;
            return selectionRect;
        }
	} 
}
