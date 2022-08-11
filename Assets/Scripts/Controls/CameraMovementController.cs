using LevelBuilder2d.View;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace LevelBuilder2d.Controls
{
    public class CameraMovementController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;    
        [SerializeField] private float _movementForce = 1.25f;
        [SerializeField] private float _scaleForce = 0.25f;

        private MainControls _mainControls;
        private ICameraSizeChanger _cameraSizeChanger;

        [Inject]
        public void Construct(ICameraSizeChanger cameraSizeChanger)
        {
            _cameraSizeChanger = cameraSizeChanger;
        }

        protected void Awake()
        {
            _mainControls = new MainControls();
            _mainControls.Camera.Moving.performed += OnCameraMoving;
            _mainControls.Camera.Zoom.performed += OnCameraZoom;
        }

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

        protected void OnEnable()
        {
            _mainControls.Enable();
        }

        protected void OnDisable()
        {
            _mainControls.Disable();
        }
    }
}