using Zenject;

namespace Basketball_YG.Test
{
    public class Installers : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<MovementManager>()
                .AsCached()
                .NonLazy();
        }
    }
}