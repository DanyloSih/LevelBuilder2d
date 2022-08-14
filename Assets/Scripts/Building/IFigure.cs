using UnityEngine;
using LevelBuilder2d.Utilities;
using LevelBuilder2d.Selection;

namespace LevelBuilder2d.Building
{
    public interface IFigure : ISelectable, IDestroyable, IObstacle
    {
        Sprite Sprite { get; set; }

        Vector2 Position { get; set; }

        Vector2 Scale { get; set; }

        Quaternion Rotation { get; set; }

        void AddRotation(Vector2 rotatonPoint, float angle);
    }
}
