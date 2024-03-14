using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Model;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camerMain;

        [Header("Skins")]
        [SerializeField] private Transform _gameplayCameraPoint;
        [SerializeField] private Transform _ballCameraPoint;

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

            Container
                .Bind<Transform>()
                .WithId(GameConstants.GameplayCameraPoint)
                .FromInstance(_gameplayCameraPoint);

            Container
                .Bind<Transform>()
                .WithId(GameConstants.BallCameraPoint)
                .FromInstance(_ballCameraPoint);
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