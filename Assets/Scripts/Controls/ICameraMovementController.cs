using LevelBuilder2d.Utilities;

namespace LevelBuilder2d.Controls
{
    public interface ICameraMovementController : IStopable
    {
        float MovementForce { get; set; }
        float ScaleForce { get; set; }
    }
}