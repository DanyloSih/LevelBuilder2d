using InspectorAddons;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.View
{
    public class MaterialColorProvider : MonoBehaviour, IColorProvider
    {
        [SerializeField] private InterfaceComponent<IMaterialProvider> _materialProviderComponent;
        [SerializeField] private string _shaderColorVariableName = "_BaseColor";

        private IMaterialProvider _materialProvider;

        [Inject]
        public void Construct() 
        {
            _materialProvider = _materialProviderComponent.Interface;
        }

        public Color Color
        { 
            get => _materialProvider.Material.GetColor(_shaderColorVariableName);
            set => _materialProvider.Material.SetColor(_shaderColorVariableName, value);
        }
    }
}
