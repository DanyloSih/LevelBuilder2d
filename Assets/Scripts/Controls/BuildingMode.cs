using LevelBuilder2d.Building;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.Controls
{
    public class BuildingMode : ModeBase
    {
        [SerializeField] private GameObject _figuresSelectingWindow;

        private IFigureSpawner _figureSpawner;

        [Inject]
        public void Construct(IFigureSpawner figureSpawner) 
        {
            _figureSpawner = figureSpawner;
            OnDeactivated();
        }

        protected override void OnActivated()
        {
            _figureSpawner.Resume();
            _figuresSelectingWindow.SetActive(true);
        }

        protected override void OnDeactivated()
        {
            _figureSpawner.Stop();
            _figuresSelectingWindow.SetActive(false);
        }
    }
}
