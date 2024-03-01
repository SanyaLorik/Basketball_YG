using Basketball_YG.Additional;
using Basketball_YG.Core;
using Basketball_YG.Model;
using Basketball_YG.View;
using System;
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
               .WithId("PlatformTransform")
               .FromInstance(_platform)
               .AsCached();
        }

        private void BindView()
        {
            Container
                .Bind<ITransformableView>()
                .WithId("PlatformView")
                .To<PlatformView>()
                .AsCached();
        }

        private void BindModel()
        {
            Container
                .Bind<ITransformableModel>()
                .WithId("PlatformModel")
                .To<PlatformModel>()
                .AsCached();
        }

        private void BindRangeLimits()
        {
            Container
                .Bind<RangeValues>()
                .WithId("PlatfromRangeValues")
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