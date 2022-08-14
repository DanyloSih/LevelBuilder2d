using InspectorAddons;
using LevelBuilder2d.Selection;
using LevelBuilder2d.Utilities;
using LevelBuilder2d.View;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace LevelBuilder2d.Building
{
    public class Figure : DestroyableMonoBehaviour, IFigure
    {
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private InterfaceComponent<ISpriteProvider> _spriteProviderComponent;
        [SerializeField] private InterfaceComponent<IColorProvider> _bodyColorProviderComponent;
        [SerializeField] private Color _selectedBodyColor;

        private ISpriteProvider _spriteProvider;
        private IColorProvider _bodyColorProvider;
        private Color _startBodyColor;
        private bool _isSelected = false;

        public event UnityAction<ISelectable> Selected;
        public event UnityAction<ISelectable> Unselected;

        public bool IsSelected { get => _isSelected; }
        public Sprite Sprite 
        {
            get => _spriteProvider.Sprite; 
            set => _spriteProvider.Sprite = value;
        }
        public Vector2 Position 
        { 
            get => transform.position; 
            set => transform.position = value; 
        }
        public Vector2 Scale 
        { 
            get => transform.localScale; 
            set => transform.localScale = value; 
        }
        public Quaternion Rotation 
        {
            get => transform.rotation; 
            set => transform.rotation = value;
        }
        public Vector3 Center { get => _collider2D.bounds.center; }

        [Inject]
        public void Construct()
        {
            _bodyColorProvider = _bodyColorProviderComponent.Interface;
            _spriteProvider = _spriteProviderComponent.Interface;   
            _startBodyColor = _bodyColorProvider.Color;
        }

        public void AddRotation(Vector2 rotatonPoint, float angle)
            => transform.RotateAround(rotatonPoint, new Vector3(0, 0, 1), angle);
         
        public void Select()
        {
            if (_isSelected == true)
                return;

           _bodyColorProvider.Color = _selectedBodyColor;
            _isSelected = true;
            Selected?.Invoke(this);
        }

        public void Unselect()
        {
            if (_isSelected == false)
                return;

            _bodyColorProvider.Color = _startBodyColor;
            _isSelected = false;
            Unselected?.Invoke(this);
        }

        public Vector3 GetClosestPoint(Vector3 target)
            => _collider2D.ClosestPoint(target);
    }
}
