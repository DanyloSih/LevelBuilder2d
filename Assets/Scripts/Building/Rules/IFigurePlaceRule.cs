using UnityEngine;

namespace LevelBuilder2d.Building.Rules
{
    public interface IFigurePlaceRule
    {
        bool IsCanPlaceFigureAt(IFigure figure, Vector2 placePosition);
    }
}
