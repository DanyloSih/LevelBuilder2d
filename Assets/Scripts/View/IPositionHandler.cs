using UnityEngine;
using UnityEngine.Events;

namespace LevelBuilder2d.View
{
    public interface IPositionHandler
    {
        event UnityAction<IPositionHandler> OnPositionChanged;

        Vector3 Position { get; set; }
    }
}