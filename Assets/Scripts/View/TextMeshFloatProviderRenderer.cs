using System;
using InspectorAddons;
using TMPro;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.View
{
    public class TextMeshFloatProviderRenderer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private InterfaceComponent<IFloatProvider> _floatProviderComponent;
        [SerializeField] private int _roundingDigits = 2;

        private IFloatProvider _floatProvider;

        [Inject]
        public void Construct()
        {
            _floatProvider = _floatProviderComponent.Interface;
            _floatProvider.OnValueChanged += OnValueChanged;
        }

        protected void OnEnable()
        {
            UpdateText();
        }

        private void OnValueChanged(IFloatProvider floatProvider)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            _textMeshPro.text = MathF.Round(_floatProvider.FloatValue, _roundingDigits).ToString();
        }
    }
}
