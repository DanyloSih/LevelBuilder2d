using LevelBuilder2d.View;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.Controls
{
    public class CameraMovementController : MonoBehaviour
    {
        [SerializeField] private float _scaleForce = 0.25f;
        private ICameraSizeChanger _cameraSizeChanger;

        [Inject]
        public void Construct(ICameraSizeChanger cameraSizeChanger)
        {
            _cameraSizeChanger = cameraSizeChanger;
        }

        public void Update()
        {
            _cameraSizeChanger.OrthographicSize += Input.mouseScrollDelta.y * _scaleForce;
        }
    }
}
