using UnityEngine.Events;

namespace LevelBuilder2d.Selection
{
    public interface ISelectable
    {
        event UnityAction<ISelectable> Selected;

        event UnityAction<ISelectable> Unselected;
        
        bool IsSelected { get; }

        void Select();

        void Unselect();
    }
}
