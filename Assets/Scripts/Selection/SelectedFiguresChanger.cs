using System;
using InspectorAddons;
using LevelBuilder2d.Utilities;
using LevelBuilder2d.View;
using LevelBuilder2d.View.Windows;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.Selection
{
    public abstract class SelectedFiguresChanger : ToggleUser
    {
        [SerializeField] private float _startProviderValue = 1.0f;
        [SerializeField] private InterfaceComponent<IWindow> _providerViewComponent;
        [SerializeField] private InterfaceComponent<IFloatProvider> _floatProviderComponent;

        private Vector3 _startWindowPosition;

        protected IWindow ProviderView { get; private set; }

        protected Rect SelectionRect { get => FiguresSelector.SelectionRect; }

        protected IFiguresSelector FiguresSelector { get; private set; }

        protected IFloatProvider FloatProvider { get; private set; }

        [Inject]
        public void BaseConstruct(IFiguresSelector figuresSelector)
        {
            FiguresSelector = figuresSelector;
            ProviderView = _providerViewComponent.Interface;
            FloatProvider = _floatProviderComponent.Interface;

            _startWindowPosition = ProviderView.Position;
            ProviderView.Hide();
        }

        protected void OnDestroy()
        {
            OnDestroying();
        }

        protected void OnEnable()
        {
            FloatProvider.OnValueChanged += OnFloatProviderValueChanged;
            FiguresSelector.SelectionChanged += OnSelectionChanging;
            OnEnabling();
        }       

        protected void OnDisable()
        {
            FloatProvider.OnValueChanged -= OnFloatProviderValueChanged;
            FiguresSelector.SelectionChanged -= OnSelectionChanging;
            OnDisabling();
            Toggle.isOn = false;
        }

        protected virtual void OnDestroying() { }

        protected virtual void OnEnabling() { }

        protected virtual void OnDisabling() { }

        protected virtual void OnSelectionChanged(IFiguresSelector figuresSelector) { }

        protected virtual void UpdateProviderView()
        {
            if (SelectionRect == default(Rect))
                ProviderView.Position = _startWindowPosition;
            else
                ProviderView.Position = Camera.main.WorldToScreenPoint(SelectionRect.center);
        }

        protected virtual void OnValueToggledExtension(bool value) { }

        protected sealed override void OnValueToggled(bool value)
        {
            if (value)
                ProviderView.Show();
            else
                ProviderView.Hide();

            FloatProvider.FloatValue = _startProviderValue;
            OnValueToggledExtension(value);
        }

        protected abstract void OnFloatProviderValueChanged(IFloatProvider floatProvider);

        private void OnSelectionChanging(IFiguresSelector figuresSelector)
        {
            UpdateProviderView();
            OnSelectionChanged(figuresSelector);
        }
    }
}