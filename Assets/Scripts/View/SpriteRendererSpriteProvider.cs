using DigitalRuby.AdvancedPolygonCollider;
using UnityEngine;

namespace LevelBuilder2d.View
{
    public class SpriteRendererSpriteProvider : MonoBehaviour, ISpriteProvider
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private AdvancedPolygonCollider _advancedPolygonCollider;

        public Sprite Sprite
        {
            get => _spriteRenderer.sprite;

            set 
            {
                _spriteRenderer.sprite = value;

                _advancedPolygonCollider.Initialize();

                _advancedPolygonCollider.RecalculatePolygon();
            }
        }
    }
}
