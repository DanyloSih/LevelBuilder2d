using Zenject;

namespace LevelBuilder2d.Controls
{
    public class MovementMode : ModeBase
    {
        private ICameraMovementController _cameraMovementController;

        [Inject]
        public void Construct(
            ICameraMovementController cameraMovementController)
        {
            _cameraMovementController = cameraMovementController;
            OnDeactivated();
        }

        protected override void OnActivated()
            => _cameraMovementController.Resume();

        protected override void OnDeactivated()
            => _cameraMovementController.Stop();
    }
}
