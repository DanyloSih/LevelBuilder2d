using InspectorAddons;
using LevelBuilder2d.Controls;
using LevelBuilder2d.Utilities;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.Building
{
    public class SlectedFigureFactory : ModesSwitcherBase<IFigureMode>, IFigureFactory
    {
        [SerializeField] private InterfaceComponent<IFigure> _figurePrefab;

        private DiContainer _container;
        private IContainer<IFigure> _figureCollection;

        [Inject]
        public void Construct(
            DiContainer container,
            IContainer<IFigure> figureContainer)
        {
            _container = container;
            _figureCollection = figureContainer;
        }

        public bool TryCreateFigure(out IFigure figureInstance)
        {
            Sprite sprite = GetSpriteInFirstActiveFigureMode();
            figureInstance = null;

            if (sprite == null)
                return false;

            figureInstance = IntantiateFigure(sprite);
            _figureCollection.Add(figureInstance);
            return true;
        }

        [ContextMenu("Find Figure Modes In Children")]
        public void FindFigureModesInChildren()
            => FindTInChildren();

        protected void Awake()
        {
            Modes[0].Activate();
        }

        private Sprite GetSpriteInFirstActiveFigureMode()
        {
            foreach (var item in Modes)
                if (item.IsActivated)
                    return item.GetFigureSprite();

            return null;
        }

        private IFigure IntantiateFigure(Sprite sprite) 
        {
            GameObject obj = _container.InstantiatePrefab(_figurePrefab.Object);
            Component component = obj.GetComponent(typeof(IFigure));
            IFigure figure = (IFigure)component;

            figure.Sprite = sprite;
            return figure;
        }
    }
}
