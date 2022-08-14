using UnityEngine;
using UnityEngine.UI;

namespace LevelBuilder2d.View
{
    public class ImageUIMaterialProvider : MonoBehaviour, IMaterialProvider
    {
        [SerializeField] private Image _image;

        public Material Material { get => _image.material; }
    }
}
