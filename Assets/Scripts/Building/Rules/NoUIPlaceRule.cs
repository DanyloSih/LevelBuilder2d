using LevelBuilder2d.Utilities;
using UnityEngine;

namespace LevelBuilder2d.Building.Rules
{
    public class NoUIPlaceRule : MonoBehaviour, IFigurePlaceRule
    {
        OverUITester _overUITester;

        public void Awake()
        {
            _overUITester = new OverUITester(LayerMask.NameToLayer("UI"));
        }

        public bool IsCanPlaceFigureAt(IFigure figure, Vector2 placePosition)
        {
            return !_overUITester.IsPointerOverUIElement();
        }
    }
}
