using UnityEngine.Events;

namespace LevelBuilder2d.View
{
    public interface ICameraSizeChanger
    {
        event UnityAction<ICameraSizeChanger> OrthographicSizeChanged;

        float OrthographicSize { get; set; }
    }
}
