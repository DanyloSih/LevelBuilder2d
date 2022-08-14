using UnityEngine.Events;

namespace LevelBuilder2d.Utilities
{
    public interface IDestroyable
    {
        public event UnityAction<IDestroyable> Destroyed;

        public void Destroy();
    }
}
