using LevelBuilder2d.Controls;
using UnityEngine;

namespace LevelBuilder2d.Building
{
    public interface IFigureMode : IMode
    {
        public Sprite GetFigureSprite();
    }
}
