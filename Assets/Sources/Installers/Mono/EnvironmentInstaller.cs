using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Model;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [Header("Cameras")]
        [SerializeField] private Camera _camerMain;
        [SerializeField] private Transform _gameplayCameraPoint;
        [SerializeField] private Transform _ballCameraPoint;
        [SerializeField] private Transform _siteCameraPoint;

        public override void InstallBindings()
        {
            //BindBallPool();
            BindCameras();
            BindCameraMovement();
            BindMoney();
        }

        private void BindBallPool()
        {
            Container
                .BindMemoryPool<Ball, BallPool>();
        }

        private void BindCameras()
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
                .WithId(GameConstants.BallSkinCameraPoint)
                .FromInstance(_ballCameraPoint);

            Container
                .Bind<Transform>()
                .WithId(GameConstants.SiteSkinCameraPoint)
                .FromInstance(_siteCameraPoint);
        }

        private void BindCameraMovement()
        {
            Container
                .BindInterfacesAndSelfTo<CameraMovementByClicking>()
                .AsCached()
                .NonLazy();
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