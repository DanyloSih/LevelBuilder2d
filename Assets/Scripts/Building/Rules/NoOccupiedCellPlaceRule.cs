using LevelBuilder2d.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace LevelBuilder2d.Building.Rules
{
    public class NoOccupiedCellPlaceRule : MonoBehaviour, IFigurePlaceRule
    {
        private IContainer<IFigure> _figureContainer;

        [Inject]
        public void Construct(IContainer<IFigure> figureContainer) 
        {
            _figureContainer = figureContainer;
        }

        public bool IsCanPlaceFigureAt(IFigure figure, Vector2 placePosition)
        {
            foreach (var item in _figureContainer.GetObjects())
            {
                if (item == figure)
                    continue;

                Vector3 v3PlacePosition = placePosition;
                if (v3PlacePosition == item.Position)
                    return false;
            }

            return true;
        }
    }
}
