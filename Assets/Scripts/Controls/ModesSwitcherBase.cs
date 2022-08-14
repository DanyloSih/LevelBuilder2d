using System.Collections.Generic;
using InspectorAddons;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.Controls
{
    public abstract class ModesSwitcherBase<T> : MonoBehaviour
        where T: class, IMode
    {
        [SerializeField] protected List<InterfaceComponent<T>> ModesComponents;

        protected List<T> Modes = new List<T>();

        [Inject]
        public void ConstructBase()
        {
            FindTInChildren();
            DeactivateAll();
        }

        public void DeactivateAll()
        {
            foreach (var item in Modes)
                item.Deactivate();
        }

        public void FindTInChildren()
        {
            var modesComponents = GetComponentsInChildren(typeof(T));
            List<InterfaceComponent<T>> modes = new List<InterfaceComponent<T>>();

            foreach (var item in modesComponents)
                if (item != null)
                    modes.Add(new InterfaceComponent<T>() { Object = item });

            ModesComponents = modes;

            CastModeComponentsToInterfaces();
        }

        protected void OnDestroy()
        {
            UnsubscribeFromModes();
        }

        protected virtual void OnModeActivating(T mode) { }
     
        protected void UnsubscribeFromModes()
        {
            foreach (var item in Modes)
                item.Activated -= OnModeActivated;
        }

        protected void DeactivateAllExcept(T mode)
        {
            foreach (var item in Modes)
                if(item != mode)
                    item.Deactivate();
        }

        private void CastModeComponentsToInterfaces()
        {
            UnsubscribeFromModes();

            Modes = new List<T>();
            foreach (var item in ModesComponents)
            {
                var mode = item.Interface;
                mode.Activated += OnModeActivated;
                Modes.Add(mode);
            }
        }

        private void OnModeActivated(IMode mode)
        {
            OnModeActivating((T)mode);
            DeactivateAllExcept((T)mode);
        }
    }
}
