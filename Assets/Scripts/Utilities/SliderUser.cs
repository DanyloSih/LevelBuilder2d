using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LevelBuilder2d.Utilities
{
    [RequireComponent(typeof(Slider))]
    public class SliderUser : MonoBehaviour
    {
        protected Slider Slider { get; private set; }

        [Inject]
        public void BaseConstruct()
        {
            Slider = GetComponent<Slider>();
        }
    }
}
