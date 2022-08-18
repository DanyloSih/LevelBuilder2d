using LevelBuilder2d.View;
using UnityEngine;

namespace LevelBuilder2d.Selection
{
    public class SelectedFiguresScaleChanger : SelectedFiguresChanger
    {
        protected override void OnFloatProviderValueChanged(IFloatProvider floatProvider)
        {
            if (Toggle.isOn && Toggle.gameObject.activeInHierarchy)
                foreach (var item in FiguresSelector.GetSelectedFigures())
                    item.Scale = Vector3.one * floatProvider.FloatValue;
        }
    }
}
