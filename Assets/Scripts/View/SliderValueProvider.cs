using LevelBuilder2d.Utilities;
using UnityEngine.Events;

namespace LevelBuilder2d.View
{
    public class SliderValueProvider : SliderUser, IFloatProvider
    {
        public float FloatValue 
        { 
            get => Slider.value; 

            set
            {
                if (Slider.value == value)
                    return;

                Slider.value = value;
                OnValueChanged?.Invoke(this);
            } 
        }

        public event UnityAction<IFloatProvider> OnValueChanged;
    }
}
