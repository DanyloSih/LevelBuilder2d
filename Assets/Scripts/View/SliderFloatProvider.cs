using LevelBuilder2d.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace LevelBuilder2d.View
{
    [RequireComponent(typeof(Slider))]
    public class SliderFloatProvider : MonoBehaviour, IFloatProvider
    {
        [SerializeField] private float _sliderStep = 0.2f;

        private Slider _slider; 
        
        public float FloatValue 
        { 
            get => RoundToStep(_slider.value);

            set 
            {
                _slider.value = RoundToStep(value);
                OnValueChanged?.Invoke(this);
            }
        }

        public event UnityAction<IFloatProvider> OnValueChanged;

        [Inject]
        public void Construct()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(OnSliderValueChanging);
        }

        protected virtual void OnSliderValueChanged(float value) { }

        private float RoundToStep(float v)
            => ValueToStepRounder.RoundToStep(v, _sliderStep);

        private void OnSliderValueChanging(float value)
        {
            OnSliderValueChanged(value);
            OnValueChanged?.Invoke(this);
        }
    }
}
