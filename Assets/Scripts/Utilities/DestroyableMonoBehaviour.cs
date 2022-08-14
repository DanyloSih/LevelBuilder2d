using System;
using UnityEngine;
using UnityEngine.Events;

namespace LevelBuilder2d.Utilities
{
    public class DestroyableMonoBehaviour : MonoBehaviour, IDestroyable
    {
        public event UnityAction<IDestroyable> Destroyed;

        public void Destroy()
        {
            Destroy(gameObject);
        }

        protected void OnDestroy()
        {
            if (!gameObject.scene.isLoaded)
                return;

            OnDestroying();
            Destroyed?.Invoke(this);
        }

        protected virtual void OnDestroying() { }
    }
}
