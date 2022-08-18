using LevelBuilder2d.Utilities;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.Selection
{
    public class SelectionTranslator : ButtonUser
    {
        [SerializeField] private Vector2 _translationVector;

        private IFiguresSelector _figuresSelector;

        [Inject]
        public void Construct(IFiguresSelector figuresSelector)
        {
            _figuresSelector = figuresSelector;
        }

        protected override void OnButtonClicked()
        {
            foreach (var item in _figuresSelector.GetSelectedFigures())
                item.Position += new Vector3(_translationVector.x, _translationVector.y);
        }
    }
}
