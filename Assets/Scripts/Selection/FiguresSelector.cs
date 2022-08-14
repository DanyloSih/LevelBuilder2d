using System.Collections.Generic;
using System.Collections.ObjectModel;
using LevelBuilder2d.Building;
using LevelBuilder2d.Controls;
using LevelBuilder2d.Utilities;
using UnityEngine;
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
			_mainControls.FigureSelector.SlectionPointerMove.performed += OnSelectionPointerMove;
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

		private Vector2 GetSelectionPointerPosition()
			=> _mainControls.FigureSelector.SlectionPointerMove.ReadValue<Vector2>();

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
        }

        private void UnsubscribeFromSelectedFigure(object selectedFigure) 
		{
			IFigure figure = (IFigure)selectedFigure;
			figure.Destroyed -= OnSelectedFigureDestroyed;
			figure.Unselected -= OnSelectedFigureUnselected;
			_selectedFigures.Remove(figure);
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

		ReadOnlyCollection<IFigure> IFiguresSelector.GetSelectedFigures()
		{
            IFigure[] copy = new IFigure[_selectedFigures.Count];
            _selectedFigures.CopyTo(copy, 0);
            return new ReadOnlyCollection<IFigure>(copy);
        }
	} 
}
