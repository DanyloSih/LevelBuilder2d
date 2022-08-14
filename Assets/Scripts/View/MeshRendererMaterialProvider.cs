using UnityEngine;

namespace LevelBuilder2d.View
{
    public class MeshRendererMaterialProvider : MonoBehaviour, IMaterialProvider
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        public Material Material { get => _meshRenderer.material; }
    }
}
