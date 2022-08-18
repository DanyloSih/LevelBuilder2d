using LevelBuilder2d.Building;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace LevelBuilder2d.Controls
{
    public class FigureSpawnerController : MonoBehaviour
    {
        private MainControls _mainControls;
        private IFigureSpawner _figureSpawner;

        [Inject]
        public void Construct(IFigureSpawner figureSpawner)
        {
            _figureSpawner = figureSpawner;
        }

        protected void Awake()
        {
            _mainControls = new MainControls();
            _mainControls.FigureSpawner.Spawn.performed += OnFigureSpawn;
        }

        protected void OnEnable()
        {
            _mainControls.Enable();
        }

        protected void OnDisable()
        {
            _mainControls.Disable();
        }

        private void OnFigureSpawn(InputAction.CallbackContext obj)
        {
            Vector2 spawnPosition
                = Camera.main.ScreenToWorldPoint(
                    _mainControls.FigureSpawner.SpawnPointerPosition.ReadValue<Vector2>());
            _figureSpawner.SpawnAt(spawnPosition);
        }
    }
}
