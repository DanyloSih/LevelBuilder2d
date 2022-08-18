using System.Collections.ObjectModel;
using LevelBuilder2d.Building;
using LevelBuilder2d.View;
using UnityEngine;

namespace LevelBuilder2d.Selection
{
    public class SelectedFiguresRotator : SelectedFiguresChanger
    {
        protected override void OnFloatProviderValueChanged(IFloatProvider floatProvider)
        {
            foreach (IFigure item in FiguresSelector.GetSelectedFigures())
            {
                item.SetRotationAroundPoint(SelectionRect.center, floatProvider.FloatValue);
            }
        }
    }
}
