using UnityEngine;

namespace LevelBuilder2d.View
{
    public class SpriteRendererColorProvider : MonoBehaviour, IColorProvider
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public Color Color 
        { 
            get => _spriteRenderer.color; 

            set => _spriteRenderer.color = value;
        }
    }
}
