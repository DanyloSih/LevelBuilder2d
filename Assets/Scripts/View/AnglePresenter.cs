using System;
using InspectorAddons;
using LevelBuilder2d.Utilities;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace LevelBuilder2d.View
{
    public class AnglePresenter : MonoBehaviour, IFloatProvider
    {
        [SerializeField] private InterfaceComponent<IPositionHandler> _pointerPositionHandlerComponent;
        [SerializeField] private RectTransform _circleRectTransform;
        [SerializeField] private float _pointerMoveStep = 0.5f;

        private IPositionHandler _pointerPositionHandler;

        public float FloatValue 
        { 
            get 
            {
                Vector2 directionToPointer = DirectionToPointer;
                float factor = directionToPointer.y < 0 ? -1 : 1;
                return RoundToStep(Vector2.Angle(Vector2.right, directionToPointer) * factor);
            }

            set
            {
                Vector2 direction = Quaternion.Euler(new Vector3(0, 0, RoundToStep(value)))
                                    * Vector2.right;
                SetPointerByAngle(direction);
            }
        }

        private float RoundToStep(float v)
            => ValueToStepRounder.RoundToStep(v, _pointerMoveStep);

        private Rect CircleRect => _circleRectTransform.rect;

        private Vector2 DirectionToPointer
            => (_pointerPositionHandler.Position - _circleRectTransform.position).normalized;

        public event UnityAction<IFloatProvider> OnValueChanged;

        [Inject]
        public void Construct()
        {
            _pointerPositionHandler = _pointerPositionHandlerComponent.Interface;
            _pointerPositionHandler.OnPositionChanged += OnPointerMoved;
        }

        private void OnPointerMoved(IPositionHandler pointer)
        {
            SetPointerByAngle(DirectionToPointer);
        }

        private void SetPointerByAngle(Vector2 directionToPointer)
        {
            Rect rect = CircleRect;
            Vector2 newPointerPosition = _circleRectTransform.position;
            newPointerPosition.x += rect.width / 2 * directionToPointer.x;
            newPointerPosition.y += rect.height / 2 * directionToPointer.y;
            _pointerPositionHandler.Position = newPointerPosition;
            OnValueChanged?.Invoke(this);
        }
    }
}
