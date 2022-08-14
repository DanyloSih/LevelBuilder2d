using UnityEngine;
using UnityEngine.UI;

namespace LevelBuilder2d.View
{
    public class ButtonColorProvider : MonoBehaviour, IColorProvider
    {
        [SerializeField] private Button _button;

        public Color Color 
        { 
            get => _button.colors.normalColor;

            set 
            {
                ColorBlock buttonColors = _button.colors;
                buttonColors.normalColor = value;
                buttonColors.selectedColor = value;
                _button.colors = buttonColors;
            }       
        }
    }
}
