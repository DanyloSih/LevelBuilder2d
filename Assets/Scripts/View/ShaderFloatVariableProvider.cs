using InspectorAddons;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.View
{
    public class ShaderFloatVariableProvider : MonoBehaviour, IShaderVariableProvider<float>
    {
        [SerializeField] 
        private InterfaceComponent<IMaterialProvider> _materialProviderComponent;
        [SerializeField] private string _shaderVariableName;
        
        private Material _material; 

        [Inject]
        public void Construct() 
        {
            _material = _materialProviderComponent.Interface.Material;
        }

        public float ShaderVariable 
        { 
            get => _material.GetFloat(_shaderVariableName); 
            set => _material.SetFloat(_shaderVariableName, value); 
        }
    }
}
