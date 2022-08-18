using UnityEngine;
using LevelBuilder2d.Utilities;
using LevelBuilder2d.Selection;
using LevelBuilder2d.View;

namespace LevelBuilder2d.Building
{
    public interface IFigure : ISelectable, IDestroyable, IObstacle, IPositionHandler
    {
        Sprite Sprite { get; set; }

        Vector2 Scale { get; set; }

        Quaternion Rotation { get; set; }

        void SetRotationAroundPoint(Vector2 rotatonPoint, float angle);
    }
}
