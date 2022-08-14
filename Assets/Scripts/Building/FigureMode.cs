using InspectorAddons;
using LevelBuilder2d.Controls;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LevelBuilder2d.Building
{
    public class FigureMode : ModeBase, IFigureMode
    {
        [SerializeField] private Sprite _figureSprite;

        private DiContainer _container;

        [Inject]
        public void Construct(DiContainer container)
        {
            _container = container;
        }

        public Sprite GetFigureSprite()
            => _figureSprite;
    }
}
