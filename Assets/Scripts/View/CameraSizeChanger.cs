using UnityEngine;
using UnityEngine.Events;

namespace LevelBuilder2d.View
{
    public class CameraSizeChanger : MonoBehaviour, ICameraSizeChanger
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _minSize = 0.1f;

        private float _previousSize;

        public float OrthographicSize 
        { 
            get => _camera.orthographicSize; 

            set 
            {
                if (_previousSize == value
                || value < _minSize)
                    return;

                _camera.orthographicSize = value;
                _previousSize = value;
                OrthographicSizeChanged?.Invoke(this);
            } 
        }

        public event UnityAction<ICameraSizeChanger> OrthographicSizeChanged;
    }
}
