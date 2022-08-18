using System.Collections.ObjectModel;
using LevelBuilder2d.Building;
using UnityEngine;
using UnityEngine.Events;

namespace LevelBuilder2d.Selection
{
    public interface IFiguresSelector
    {
        event UnityAction<IFiguresSelector> SelectionChanged;

        public Rect SelectionRect { get; }

        ReadOnlyCollection<IFigure> GetSelectedFigures();
    }
}
