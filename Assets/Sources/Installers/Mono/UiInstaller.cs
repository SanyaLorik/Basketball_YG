using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Model;
using Basketball_YG.View;
using Basketball_YG.CompositeRoot;
using SanyaBeer.Meta;
using UnityEngine;
using Zenject;
using Basketball_YG.Counter;

namespace Basketball_YG.Installer
{
    public class UiInstaller : MonoInstaller
    {
        [Header("Main Menu")]
        [SerializeField] private ClickedCallback _startMathButton;
        [SerializeField] private ClickedCallback _skinStoreButton;
        [SerializeField] private ClickedCallback _siteStoreButton;
        [SerializeField] private ClickedCallback _settingsOpenerButton;
        [SerializeField] private ClickedCallback _gameSharingButton;
        [SerializeField] private TextSetup _scoreMain;
        [SerializeField] private TextSetup _moneyMain;
        [SerializeField] private ElementActivity _mainMenuActivity;

        [Header("Settings Menu")]
        [SerializeField] private ClickedCallback _closeSettingsMenuButton;
        [SerializeField] private ElementActivity _settingsMenuActivity;

        [Header("Gameplay Menu")]
        [SerializeField] private ElementActivity _gameplayMenuActivity;
        [SerializeField] private ElementActivityArray _gameplayMenuActivities;
        [SerializeField] private ClickedCallback _pauseOpenerButton;
        [SerializeField] private ElementActivity _timerActivity;
        [SerializeField] private Timer _timer;

        [Header("Pause Menu")]
        [SerializeField] private ElementActivity _pauseMenuActivity;
        [SerializeField] private ClickedCallback _closePauseMenuButton;

        [Header("Ball Store Menu")]
        [SerializeField] private ElementActivity _ballStoreMenuActivity;
        [SerializeField] private ClickedCallback _ballStoreNextButton;
        [SerializeField] private ClickedCallback _ballStoreBackButton;
        [SerializeField] private ClickedCallback _ballStoreSelectedButton;
        [SerializeField] private ClickedCallback _ballStoreMenuButton;
        [SerializeField] private TextSetup _ballStoreNamingText;
        [SerializeField] private TextSetup _ballStoreMoneyText;

        [Header("Site Store Menu")]
        [SerializeField] private ElementActivity _siteStoreMenuActivity;
        [SerializeField] private ClickedCallback _siteStoreNextButton;
        [SerializeField] private ClickedCallback _siteStoreBackButton;
        [SerializeField] private ClickedCallback _siteStoreSelectedButton;
        [SerializeField] private ClickedCallback _siteStoreMenuButton;
        [SerializeField] private TextSetup _siteStoreNamingText;
        [SerializeField] private TextSetup _siteStoreMoneyText;

        [Header("Speedoment Reward")]
        [SerializeField] private Transform _speedomentRewardArrow;
        [SerializeField] private MultiplayerSlot[] _multiplayerSlot;
        [SerializeField] private TextSetup _speedomentRewardmoneyText;

        public override void InstallBindings()
        {
            BindMainMenu();
            BindSettingsMenu();
            BindGameplayMenu();
            BindPauseMenu();
            BindBallStoreMenu();
            BindSiteStoreMenu();
            BindSpeedometrReward();
        }

        private void BindMainMenu()
        {
            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonStartMath)
                .FromInstance(_startMathButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonBallStore)
                .FromInstance(_skinStoreButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonSiteStore)
                .FromInstance(_siteStoreButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonSettingsOpener)
                .FromInstance(_settingsOpenerButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonGameSharing)
                .FromInstance(_gameSharingButton)
                .AsCached();

            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiMainMenuActivity)
                .FromInstance(_mainMenuActivity)
                .AsCached();

            Container
                .Bind<IMenuActivity>()
                .WithId(GameConstants.UiMainMenu)
                .To<MainMenu>()
                .AsCached();

            Container
                .BindInterfacesTo<MainMenu>()
                .AsCached();
        }

        private void BindSettingsMenu()
        {
            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonCloseSettingsMenu)
                .FromInstance(_closeSettingsMenuButton)
                .AsCached();

            Container
              .Bind<ElementActivity>()
              .WithId(GameConstants.UiSettingsMenuActivity)
              .FromInstance(_settingsMenuActivity)
              .AsCached();

            Container
                .Bind<IMenuActivity>()
                .WithId(GameConstants.UiSettingsMenu)
                .To<SettingsMenu>()
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<SettingsMenu>()
                .AsCached()
                .NonLazy();
        }

        private void BindGameplayMenu()
        {
            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonGameplayPauseOpener)
                .FromInstance(_pauseOpenerButton)
                .AsCached();

            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiGameplayMenuActivity)
                .FromInstance(_gameplayMenuActivity)
                .AsCached();

            Container
                .Bind<ElementActivityArray>()
                .WithId(GameConstants.UiGameplayPrestartMatchActivities)
                .FromInstance(_gameplayMenuActivities)
                .AsCached();

            Container
                .Bind<IMenuActivity>()
                .WithId(GameConstants.UiGameplayMenu)
                .To<GameplayMenu>()
                .AsCached();

            Container
                .BindInterfacesTo<GameplayMenu>()
                .AsCached();

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

        private void BindPauseMenu()
        {
            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonClosePauseMenu)
                .FromInstance(_closePauseMenuButton)
                .AsCached();

            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiPauseMenuActivity)
                .FromInstance(_pauseMenuActivity)
                .AsCached();

            Container
                .Bind<IMenuActivity>()
                .WithId(GameConstants.UiPauseMenu)
                .To<PauseMenu>()
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<PauseMenu>()
                .AsCached()
                .NonLazy();
        }

        private void BindBallStoreMenu()
        {
            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiBallStoreMenuActivity)
                .FromInstance(_ballStoreMenuActivity)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiBallStoreNextButton)
                .FromInstance(_ballStoreNextButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiBallStoreBackButton)
                .FromInstance(_ballStoreBackButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiBallStoreSelectedButton)
                .FromInstance(_ballStoreSelectedButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiBallStoreMenuButton)
                .FromInstance(_ballStoreMenuButton)
                .AsCached();

            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.UiBallStoreNamingText)
                .FromInstance(_ballStoreNamingText)
                .AsCached();

            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.UiBallStoreMoneyText)
                .FromInstance(_ballStoreNamingText)
                .AsCached();

            Container
                .Bind<SkinSelector>()
                .WithId(GameConstants.BallSkinSelector)
                .To<BallSkinSelector>()
                .AsCached();

            Container
                .Bind<IMenuActivity>()
                .WithId(GameConstants.UiBallStoreMenu)
                .To<BallStoreMenu>()
                .AsCached();

            Container
              .BindInterfacesAndSelfTo<BallStoreMenu>()
              .AsCached()
              .NonLazy();
        }

        private void BindSiteStoreMenu()
        {
            Container
                 .Bind<ElementActivity>()
                 .WithId(GameConstants.UiSiteStoreMenuActivity)
                 .FromInstance(_siteStoreMenuActivity)
                 .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiSiteStoreNextButton)
                .FromInstance(_siteStoreNextButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiSiteStoreBackButton)
                .FromInstance(_siteStoreBackButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiSiteStoreSelectedButton)
                .FromInstance(_siteStoreSelectedButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiSiteStoreMenuButton)
                .FromInstance(_siteStoreMenuButton)
                .AsCached();

            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.UiSiteStoreNamingText)
                .FromInstance(_siteStoreNamingText)
                .AsCached();

            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.UiSiteStoreMoneyText)
                .FromInstance(_siteStoreNamingText)
                .AsCached();

            Container
                .Bind<IMenuActivity>()
                .WithId(GameConstants.UiSiteStoreMenu)
                .To<SiteStoreMenu>()
                .AsCached();

            Container
                .Bind<SkinSelector>()
                .WithId(GameConstants.SiteSkinSelector)
                .To<SiteSkinSelector>()
                .AsCached();

            Container
              .BindInterfacesAndSelfTo<SiteStoreMenu>()
              .AsCached()
              .NonLazy();

        }

        private void BindSpeedometrReward()
        {
            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.SpeedometrRewardmoneyText)
                .FromInstance(_speedomentRewardmoneyText)
                .AsCached();

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
    }
}