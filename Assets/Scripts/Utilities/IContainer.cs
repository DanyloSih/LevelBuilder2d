using System.Collections.Generic;
using UnityEngine.Events;

namespace LevelBuilder2d.Utilities
{
    public interface IContainer<T>
        where T : class, IDestroyable
    {
        event UnityAction<T> ItemAdded;
        event UnityAction<T> ItemRemoved;

        void Add(T item);

        IEnumerable<T> GetObjects();
    }
}
