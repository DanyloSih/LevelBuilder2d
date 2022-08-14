using System.Collections.Generic;

namespace LevelBuilder2d.Building.Rules
{
    public interface IFigurePlaceRulesContainer : IFigurePlaceRule
    {
        IEnumerable<IFigurePlaceRule> GetRules();
    }
}
