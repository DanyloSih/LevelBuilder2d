using System.Collections.ObjectModel;
using LevelBuilder2d.Building;
using UnityEngine;

namespace LevelBuilder2d.Selection
{
    public interface IFiguresSelector
    {
        ReadOnlyCollection<IFigure> GetSelectedFigures();
    }
}
