using System.Collections.Generic;
using InspectorAddons;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.Building.Rules
{
    public class FigurePlaceRulesContainer : MonoBehaviour, IFigurePlaceRulesContainer
    {
        [SerializeField] private List<InterfaceComponent<IFigurePlaceRule>> _placeRuleComponents;

        private List<IFigurePlaceRule> _placeRules;

        [Inject]
        public void Construct() 
        {
            _placeRules = InterfaceComponent<IFigurePlaceRule>
                .GetInterfaces(_placeRuleComponents);
        }

        public IEnumerable<IFigurePlaceRule> GetRules()
            => _placeRules;

        public bool IsCanPlaceFigureAt(IFigure figure, Vector2 placePosition)
        {
            foreach (var item in _placeRules)
            {
                if (!item.IsCanPlaceFigureAt(figure, placePosition))
                    return false;
            }

            return true;
        }
    }
}
