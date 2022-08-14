using UnityEngine;

namespace LevelBuilder2d.Controls
{
    public class ModesSwitcher : ModesSwitcherBase<IMode>
    {
        [ContextMenu("Find Modes In Children.")]
        public void FindModesInChildren()
            => FindTInChildren();
    }
}
