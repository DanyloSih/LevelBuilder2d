using LevelBuilder2d.Building;
using LevelBuilder2d.Utilities;
using Zenject;

namespace LevelBuilder2d.Selection
{
    public class SelectionRemover : ButtonUser
    {
        private IFiguresSelector _figuresSelector;

        [Inject]
        public void Construct(IFiguresSelector figuresSelector)
        {
            _figuresSelector = figuresSelector;
        }

        protected override void OnButtonClicked()
        {
            foreach (var item in _figuresSelector.GetSelectedFigures())
                item.Unselect();
        }
    }
}
