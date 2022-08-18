using InspectorAddons;
using LevelBuilder2d.View;
using UnityEngine;

namespace LevelBuilder2d.Tests
{
    public class FloatProviderValueSetter : MonoBehaviour
    {
        [SerializeField] private InterfaceComponent<IFloatProvider> _floatProviderComponent;
        [SerializeField] private float _setValue;

        [ContextMenu("Set value.")]
        public void SetValue() 
            => _floatProviderComponent.Interface.FloatValue = _setValue;
    }
}
