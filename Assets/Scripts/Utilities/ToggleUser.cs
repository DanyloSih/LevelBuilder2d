using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LevelBuilder2d.Utilities
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleUser : MonoBehaviour
    {
        [SerializeField] private Color _isToggleOnColor;

        private Color _startColor;

        protected Toggle Toggle { get; private set; }

        [Inject]
        public void Construct()
        {
            Toggle = GetComponent<Toggle>();
            Toggle.isOn = false;
            Toggle.onValueChanged.AddListener(OnValueToggling);
            _startColor = Toggle.colors.normalColor;
        }

        protected virtual void OnValueToggled(bool value) { }

        private void OnValueToggling(bool value)
        {
            if (value)
                SetColor(_isToggleOnColor);
            else
                SetColor(_startColor);

            OnValueToggled(value);
        }

        private void SetColor(Color color)
        {
            ColorBlock colors = Toggle.colors;
            colors.normalColor = color;
            colors.selectedColor = color;
            Toggle.colors = colors;
        }
    }
}
