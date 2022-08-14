using UnityEngine;

namespace LevelBuilder2d.Controls
{
    public interface ICameraRayThrower
    {
        RaycastHit2D Throw();
    }
}
