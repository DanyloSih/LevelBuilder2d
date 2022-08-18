using UnityEngine.Events;

namespace LevelBuilder2d.View
{
    public interface IFloatProvider
    {
        event UnityAction<IFloatProvider> OnValueChanged;

        float FloatValue { get; set; }
    }
}
