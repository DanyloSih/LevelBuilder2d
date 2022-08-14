using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelBuilder2d.Controls
{
    public class CameraRayThrower : MonoBehaviour, ICameraRayThrower
    {
        public RaycastHit2D Throw()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            return Physics2D.GetRayIntersection(ray);
        }
    }
}
