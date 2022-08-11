using InspectorAddons;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.View
{
    public class CameraSizeInShaderUpdater : MonoBehaviour
    {
        [SerializeField]
        private InterfaceComponent<IShaderVariableProvider<float>> _sizeShaderVariableProviderComponent;

        private IShaderVariableProvider<float> _sizeVariableProvider;
        private ICameraSizeChanger _cameraSizeChanger;

        [Inject]
        public void Construct(ICameraSizeChanger cameraSizeChanger)
        {
            _sizeVariableProvider = _sizeShaderVariableProviderComponent.Interface;
            _cameraSizeChanger = cameraSizeChanger;

            //_sizeVariableProvider.ShaderVariable = cameraSizeChanger.OrthographicSize;

            _cameraSizeChanger.OrthographicSizeChanged += OnCameraOrtographicSizeChanged;
        }

        private void OnCameraOrtographicSizeChanged(ICameraSizeChanger cameraSizeChanger)
        {
            _sizeVariableProvider.ShaderVariable = cameraSizeChanger.OrthographicSize;
        }
    } 
}
