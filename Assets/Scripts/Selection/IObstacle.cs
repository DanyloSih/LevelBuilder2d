using UnityEngine;

namespace LevelBuilder2d.Selection
{
    public interface IObstacle
    {
        Vector3 Center { get; }  

        Vector3 GetClosestPoint(Vector3 target);
    }
}
