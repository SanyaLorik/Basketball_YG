using Basketball_YG.Additional;
using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Model;
using Basketball_YG.View;
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
            BindView();
            BindModel();

            BindRangeLimits();
            BindMovement();
        }

        private void BindTransform()
        {
            Container
               .Bind<Transform>()
               .WithId(GameConstants.PlatformTransform)
               .FromInstance(_platform)
               .AsCached();
        }

        private void BindView()
        {
            Container
                .Bind<ITransformableView>()
                .WithId(GameConstants.PlatformView)
                .To<PlatformView>()
                .AsCached();
        }

        private void BindModel()
        {
            Container
                .Bind<ITransformableModel>()
                .WithId(GameConstants.PlatformModel)
                .To<PlatformModel>()
                .AsCached();
        }

        private void BindRangeLimits()
        {
            Container
                .Bind<RangeValues>()
                .WithId(GameConstants.PlatfromRangeValues)
                .FromInstance(_limits)
                .AsCached();
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