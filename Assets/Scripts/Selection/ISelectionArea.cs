using UnityEngine;

namespace LevelBuilder2d.Selection
{
    public interface ISelectionArea
    {
        void Enable();

        void Disable();

        bool IsContain(IObstacle bounds);

        void UpdateRect(Vector2 startPoint, Vector2 endPoint);
    }
}
