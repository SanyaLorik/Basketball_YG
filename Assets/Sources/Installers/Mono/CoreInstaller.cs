using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Model;
using Basketball_YG.View;
using Basketball_YG.Wrapper;
using SanyaBeer.Additional;
using SanyaBeer.Meta;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    public class CoreInstaller : MonoInstaller
    {
        [Header("Platform")]
        [SerializeField] private Transform _platform;
        [SerializeField] private RangeValues _limits;

        [Header("Speedoment Reward")]
        [SerializeField] private Transform _speedomentRewardArrow;
        [SerializeField] private MultiplayerSlot[] _multiplayerSlot;

        [Header("Skins")]
        [SerializeField] private SkinPrefabStore _ballPrefabStore;
        [SerializeField] private SkinPrefabStore _sitePrefabStore;

        [Header("Countdown Timer")]
        [SerializeField] private ElementActivity _timerActivity;
        [SerializeField] private Timer _timer;

        public override void InstallBindings()
        {
            BindPlatfrom();
            BindSpeedometrReward();
            BindBallSkinSelector();
            BindSiteSkinSelector();
            BindCountdownTimer();
            BindBalls();
        }

        private void BindCountdownTimer()
        {
            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiGameplayTimerActivity)
                .FromInstance(_timerActivity)
                .AsCached();


            Container
                .Bind<Timer>()
                .FromInstance(_timer)
                .AsCached();
        }

        private void BindPlatfrom()
        {
            Container
               .Bind<Transform>()
               .WithId(GameConstants.PlatformTransform)
               .FromInstance(_platform)
               .AsCached();

            Container
                .Bind<IPositionView>()
                .WithId(GameConstants.PlatformView)
                .To<PlatformView>()
                .AsCached();

            Container
                .Bind<IPositionModel>()
                .WithId(GameConstants.PlatformModel)
                .To<PlatformModel>()
                .AsCached();

            Container
                .Bind<RangeValues>()
                .WithId(GameConstants.PlatfromRangeValues)
                .FromInstance(_limits)
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<PlatformMovement>()
                .AsCached()
                .NonLazy();
        }

        private void BindSpeedometrReward()
        {
            Container
                .Bind<Transform>()
                .WithId(GameConstants.RewardSpeedometrArrow)
                .FromInstance(_speedomentRewardArrow)
                .AsCached();

            Container
                .Bind<IRotatationView>()
                .WithId(GameConstants.SpeedometrView)
                .To<RewardSpeedometrView>()
                .AsCached();

            Container
                .Bind<IRotationModel>()
                .WithId(GameConstants.SpeedometrRotationModel)
                .To<RewardSpeedometrModel>()
                .AsCached();

            Container
                .Bind<IInformationSetupModel<string>>()
                .WithId(GameConstants.SpeedometrInformationModel)
                .To<RewardSpeedometrModel>()
                .AsCached();

            Container
                .Bind<MultiplayerSlot[]>()
                .WithId(GameConstants.SpeedometrMultiplayerSlot)
                .FromInstance(_multiplayerSlot)
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<RewardSpeedometr>()
                .AsCached();
        }

        private void BindBallSkinSelector()
        {
            Container
               .Bind<SkinPrefabStore>()
               .WithId(GameConstants.BallSkinPrefabStore)
               .FromInstance(_ballPrefabStore)
               .AsCached();

            Container
               .Bind<SkinSelectingView>()
               .WithId(GameConstants.BallSkinSelectingView)
               .To<BallSelectingView>()
               .AsCached();

            Container
               .Bind<SkinSelectingModel>()
               .WithId(GameConstants.BallSkinSelectingModel)
               .To<BallSelectingModel>()
               .AsCached();

            Container
               .BindInterfacesAndSelfTo<BallSelectingModel>()
               .AsCached();

            Container
               .Bind<SkinSelector>()
               .WithId(GameConstants.BallSkinSelector)
               .To<BallSkinSelector>()
               .AsCached();
        }

        private void BindSiteSkinSelector()
        {
            Container
               .Bind<SkinPrefabStore>()
               .WithId(GameConstants.SiteSkinPrefabStore)
               .FromInstance(_sitePrefabStore)
               .AsCached();

            Container
               .Bind<SkinSelectingView>()
               .WithId(GameConstants.SiteSkinSelectingView)
               .To<SiteSelectingView>()
               .AsCached();

            Container
               .Bind<SkinSelectingModel>()
               .WithId(GameConstants.SiteSkinSelectingModel)
               .To<SiteSelectingModel>()
               .AsCached();

            Container
               .BindInterfacesAndSelfTo<SiteSelectingModel>()
               .AsCached();

            Container
               .Bind<SkinSelector>()
               .WithId(GameConstants.SiteSkinSelector)
               .To<SiteSkinSelector>()
               .AsCached();
        }

        private void BindBalls()
        {
            Container
                .BindFactory<BallType, BallWrapper, BallWrapperFactory>()
                .AsCached();
        }
    }
}