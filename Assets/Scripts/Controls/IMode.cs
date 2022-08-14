using UnityEngine.Events;

namespace LevelBuilder2d.Controls
{
    public interface IMode
    {
        public event UnityAction<IMode> Activated;
        bool IsActivated { get; }

        void Activate();
        void Deactivate();
    }
}
