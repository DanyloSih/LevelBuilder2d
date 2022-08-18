using UnityEngine;
using UnityEngine.Events;

namespace LevelBuilder2d.View.Windows
{
    public class WindowBase : MonoBehaviour, IWindow
    {
        public Vector3 Position 
        { 
            get => transform.position;
            set
            {
                transform.position = value;
                OnPositionChanged?.Invoke(this);
            } 
        }

        public event UnityAction<IPositionHandler> OnPositionChanged;

        public void Hide()
            => gameObject.SetActive(false);

        public void Show()
            => gameObject.SetActive(true);
    }
}
