using Basketball_YG.Additional;
using Basketball_YG.Core;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    public class PlatformInstaller : MonoInstaller
    {
        [SerializeField] private Transform _platform;
        [SerializeField] private RangeValues _limits;

        public override void InstallBindings()
        {
            BindTransform();
            BindRangeLimits();
            BindMovement();
        }

        private void BindTransform()
        {
            Container
                .Bind<Transform>()
                .WithId("PlatfromTransform")
                .FromInstance(_platform);
        }

        private void BindRangeLimits()
        {
            Container
                .Bind<RangeValues>()
                .WithId("PlatfromRangeValues")
                .FromInstance(_limits);
        }

        private void BindMovement()
        {
            Container
                .BindInterfacesAndSelfTo<PlatformMovement>()
                .AsCached()
                .NonLazy();
        }
    }
}