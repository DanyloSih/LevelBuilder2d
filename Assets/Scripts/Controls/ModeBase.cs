using InspectorAddons;
using LevelBuilder2d.Utilities;
using LevelBuilder2d.View;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace LevelBuilder2d.Controls
{
    public class ModeBase : ButtonUser, IMode
    {
        [SerializeField] InterfaceComponent<IColorProvider> _colorProviderComponent;
        [SerializeField] private Color _activatedColor;

        private Color _startColor;
        private IColorProvider _colorProvider;
        private bool _isActivated = false;

        public event UnityAction<IMode> Activated;

        public bool IsActivated { get => _isActivated; }     

        [Inject]
        public void BaseConstruct() 
        {
            _colorProvider = _colorProviderComponent.Interface;
            _startColor = _colorProvider.Color;
        }

        public void Activate()
        {
            if (_isActivated)
                return;

            _colorProvider.Color = _activatedColor;
            _isActivated = true;
            OnActivated();
            Activated?.Invoke(this);
        }      

        public void Deactivate()
        {
            if (!_isActivated)
                return;

            _colorProvider.Color = _startColor;
            _isActivated = false;
            OnDeactivated();
        }

        protected override void OnButtonClicked()
        {
            Activate();
        }

        protected virtual void OnActivated() { }

        protected virtual void OnDeactivated() { }
    }
}
