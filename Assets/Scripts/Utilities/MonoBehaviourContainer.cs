using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LevelBuilder2d.Utilities
{
    public abstract class MonoBehaviourContainer<T> : MonoBehaviour, IContainer<T>
        where T : class, IDestroyable
    {
        public List<T> _items = new List<T>();

        public event UnityAction<T> ItemAdded;
        public event UnityAction<T> ItemRemoved;

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            if (_items.Contains(item))
                throw new ArgumentException("This object " +
                    "is already in the container!");

            OnAdding(item);

            item.Destroyed += OnItemDestroyed;
            _items.Add(item);
            ItemAdded?.Invoke(item);
        }

        public IEnumerable<T> GetObjects()
        {
            T[] clone = new T[_items.Count];
            _items.CopyTo(clone, 0);
            return clone;
        }

        protected virtual void OnDestroying(IDestroyable item) { }

        protected virtual void OnAdding(T item) { }

        private void OnItemDestroyed(IDestroyable item)
        {
            OnDestroying(item);
            item.Destroyed -= OnItemDestroyed;
            T tItem = (T)item;
            _items.Remove(tItem);
            ItemRemoved?.Invoke(tItem);
        }
    }
}
