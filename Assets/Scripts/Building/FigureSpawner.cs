using System;
using LevelBuilder2d.Building.Rules;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.Building
{
    public class FigureSpawner : MonoBehaviour, IFigureSpawner
    {
        [SerializeField] private Vector2 _offset = Vector2.one / 2;

        private IFigureFactory _figureFactory;
        private IFigurePlaceRulesContainer _figurePlaceRulesContainer;

        [Inject]
        public void Construct(
            IFigureFactory figureFactory,
            IFigurePlaceRulesContainer figurePlaceRulesContainer) 
        {
            _figureFactory = figureFactory;
            _figurePlaceRulesContainer = figurePlaceRulesContainer;
        }

        public void Stop()
        {
            enabled = false;
        }

        public void Resume()
        {
            enabled = true;
        }

        public void SpawnAt(Vector2 spawnPosition)
        {
            if (enabled == false)
                return;

            IFigure figure;
            if (_figureFactory.TryCreateFigure(out figure))
            {
                Vector2 realSpawnPosition = spawnPosition;
                realSpawnPosition -= _offset;
                realSpawnPosition.x = Mathf.Round(realSpawnPosition.x);
                realSpawnPosition.y = Mathf.Round(realSpawnPosition.y);
                realSpawnPosition += _offset;
                figure.Position = realSpawnPosition;

                if (!_figurePlaceRulesContainer.IsCanPlaceFigureAt(figure, realSpawnPosition))
                    figure.Destroy();
            }
        }    
    }
}
