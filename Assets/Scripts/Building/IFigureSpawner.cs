using LevelBuilder2d.Utilities;
using UnityEngine;

namespace LevelBuilder2d.Building
{
    public interface IFigureSpawner : IStopable
    {
        public void SpawnAt(Vector2 spawnPosition);
    }
}
