using System;
using UnityEngine;
using UnityEngine.UI;

namespace LevelBuilder2d.Utilities
{
    [RequireComponent(typeof(Button))]
    public class ButtonUser : MonoBehaviour
    {
        private Button _button;

        protected void Awake()
        {
            OnAwakening();
            _button = GetComponent<Button>();
        }

        protected void OnEnable()
        {
            OnEnabling();
            _button.onClick.AddListener(OnButtonClicked);
        }
  
        protected void OnDisable()
        {
            OnDisabling();
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        protected virtual void OnAwakening() { }

        protected virtual void OnEnabling() { }

        protected virtual void OnDisabling() { }
        
        protected virtual void OnButtonClicked() { }
    }
}
