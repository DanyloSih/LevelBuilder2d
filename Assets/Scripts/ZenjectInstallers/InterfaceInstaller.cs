using System;
using Zenject;

namespace LevelBuilder2d.ZenjectInstallers
{
    public class InterfaceInstaller<T> : MonoInstaller
        where T : class
    {
        public override void InstallBindings()
        {
            T component = GetComponent(typeof(T)) as T;
            if (component == null)
                throw new Exception("The installer must be located " +
                    "on the same object as the component being installed.\n" +
                    $"Installing type: {typeof(T).Name}.");

            Container.Bind<T>().FromInstance(component);
        }
    }
}
