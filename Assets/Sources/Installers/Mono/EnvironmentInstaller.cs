using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Model;
using SanyaBeer.Meta;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [Header("Cameras")]
        [SerializeField] private Camera _camerMain;
        [SerializeField] private ElementActivity _gameplayCameraActivity;
        [SerializeField] private ElementActivity _ballCameraActivity;
        [SerializeField] private ElementActivity _siteCameraActivity;

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
                .Bind<ElementActivity>()
                .WithId(GameConstants.GameplayCameraActivity)
                .FromInstance(_gameplayCameraActivity);

            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.BallSkinCameraActivity)
                .FromInstance(_ballCameraActivity);

            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.SiteSkinCameraActivity)
                .FromInstance(_siteCameraActivity);
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