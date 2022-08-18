using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Zenject;

namespace LevelBuilder2d.View
{
    [RequireComponent(typeof(RectTransform))]
    public class RectTransformMover : MonoBehaviour, IPositionHandler
    {
        private MainControls _mainControls;
        private RectTransform _rectTransform;
        private bool _isDragging = false;

        public event UnityAction<IPositionHandler> OnPositionChanged;

        public Vector3 Position 
        { 
            get => _rectTransform.position; 
            set => _rectTransform.position = value; 
        }

        private Vector3 PointerPosition
            => _mainControls.FigureSelector.SelectionPointerMove.ReadValue<Vector2>();

        [Inject]
        public void Construct()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        protected void Awake()
        {
            _mainControls = new MainControls();
            _mainControls.FigureSelector.SelectionPointerMove.performed 
                += OnSelectionPointerMoved;
            _mainControls.FigureSelector.StartSelection.performed += OnSelectionStart;
            _mainControls.FigureSelector.StopSelection.performed += OnSelectionStop;
        }

        protected void OnEnable()
        {
            _mainControls.Enable();
        }

        protected void OnDisable()
        {
            _mainControls.Disable();
        }

        private void OnSelectionStop(InputAction.CallbackContext obj)
        {
            _isDragging = false;
        }

        private void OnSelectionStart(InputAction.CallbackContext obj)
        {
            _isDragging
                = _rectTransform.rect.Contains(PointerPosition - _rectTransform.position);
        }

        private void OnSelectionPointerMoved(InputAction.CallbackContext obj)
        {
            if (_isDragging && _rectTransform.position != PointerPosition)
            {
                _rectTransform.position = PointerPosition;
                OnPositionChanged?.Invoke(this);
            }
        }
    }
}
