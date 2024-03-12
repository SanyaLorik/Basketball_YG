using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Model;
using System;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camerMain;

        public override void InstallBindings()
        {
            //BindBallPool();
            BindCamera();
            BindMoney();
        }

        private void BindBallPool()
        {
            Container
                .BindMemoryPool<Ball, BallPool>();
        }

        private void BindCamera()
        {
            Container
                .Bind<Camera>()
                .WithId(GameConstants.CameraMain)
                .FromInstance(_camerMain);
        }

        private void BindMoney()
        {
            Container
                .Bind<IMoney>()
                .WithId(GameConstants.MoneyMatch)
                .To<MatchMoney>()
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<MatchMoney>()
                .AsCached();
        }
    }
}