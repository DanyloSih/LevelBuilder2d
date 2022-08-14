using InspectorAddons;
using LevelBuilder2d.Utilities;
using UnityEngine;
using Zenject;

namespace LevelBuilder2d.Controls
{
    public class SelectionMode : ModeBase
    {
        [SerializeField] private GameObject _selectionActionsPanel;
        [SerializeField] private InterfaceComponent<IStopable> _figureSelectorComponent;

        private IStopable _figureSelector;

        [Inject]
        public void Construct()
        {
            _figureSelector = _figureSelectorComponent.Interface;
            OnDeactivated();
        }

        protected override void OnActivated()
        {
            _selectionActionsPanel.SetActive(true);
            _figureSelector.Resume();
            
        }

        protected override void OnDeactivated()
        {
            _selectionActionsPanel.SetActive(false);
            _figureSelector.Stop();
        }
    }
}
