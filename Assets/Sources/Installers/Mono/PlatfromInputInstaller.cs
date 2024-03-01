using Basketball_YG.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Basketball_YG.Installer
{
    public class PlatfromInputInstaller : MonoInstaller
    {
        [SerializeField] private EventTrigger _surface;
        [SerializeField] private LayerMask _wallmask;

        public override void InstallBindings()
        {
            BindTouchInput();
        }

        private void BindTouchInput()
        {
            Container
                .Bind<EventTrigger>()
                .WithId("PlatfromTouchInput")
                .FromInstance(_surface);

            Container
                .Bind<LayerMask>()
                .WithId("WallMask")
                .FromInstance(_wallmask);

            Container
                .BindInterfacesAndSelfTo<PlatfromTouchInput>()
                .AsCached();
        }
    }
}