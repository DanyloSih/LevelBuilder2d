using LevelBuilder2d.View;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace LevelBuilder2d.Controls
{
    public class CameraMovementController : MonoBehaviour, ICameraMovementController
    {
        [SerializeField] private Camera _camera;    
        [SerializeField] private float _movementForce = 1.25f;
        [SerializeField] private float _scaleForce = 0.25f;

        private MainControls _mainControls;
        private ICameraSizeChanger _cameraSizeChanger;

        public float MovementForce { get => _movementForce; set => _movementForce = value; }
        public float ScaleForce { get => _scaleForce; set => _scaleForce = value; }

        [Inject]
        public void Construct(ICameraSizeChanger cameraSizeChanger)
        {
            _cameraSizeChanger = cameraSizeChanger;
        }

        public void Stop()
            => enabled = false;

        public void Resume()
            => enabled = true;

        protected void Awake()
        {
            _mainControls = new MainControls();
            _mainControls.Camera.Moving.performed += OnCameraMoving;
            _mainControls.Camera.Zoom.performed += OnCameraZoom;
        }

        protected virtual void OnEnable()
            => _mainControls.Enable();  

        protected virtual void OnDisable()
            => _mainControls.Disable();

        private void OnCameraZoom(InputAction.CallbackContext obj)
        {
            float delta = obj.ReadValue<float>();
            _cameraSizeChanger.OrthographicSize += delta * _scaleForce;
        }

        private void OnCameraMoving(InputAction.CallbackContext obj)
        {         
            _camera.transform.Translate(
                obj.ReadValue<Vector2>()
                * _movementForce 
                * _cameraSizeChanger.OrthographicSize);
        }
    }
}