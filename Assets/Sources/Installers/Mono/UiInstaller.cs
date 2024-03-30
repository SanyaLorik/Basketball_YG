using Basketball_YG.CompositeRoot;
using Basketball_YG.Config;
using Basketball_YG.Counter;
using SanyaBeer.Meta;
using System;
using UnityEngine;
using Zenject;

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
        [SerializeField] private TextSetup _gameplayCounterText;
        [SerializeField] private EachElementActivityArray _iconHearth;

        [Header("Pause Menu")]
        [SerializeField] private ElementActivity _pauseMenuActivity;
        [SerializeField] private ClickedCallback _closePauseMenuButton;

        [Header("Ball Store Menu")]
        [SerializeField] private ElementActivity _ballStoreMenuActivity;
        [SerializeField] private ElementActivity _ballStoreSelectedActivity;
        [SerializeField] private ElementActivity _ballStoreBoughtActivity;
        [SerializeField] private ElementActivity _ballStoreVideoActivity;
        [SerializeField] private ClickedCallback _ballStoreNextButton;
        [SerializeField] private ClickedCallback _ballStoreBackButton;
        [SerializeField] private ClickedCallback _ballStoreSelectedButton;
        [SerializeField] private ClickedCallback _ballStoreBoughtButton;
        [SerializeField] private ClickedCallback _ballStoreVideoButton;
        [SerializeField] private ClickedCallback _ballStoreMenuButton;
        [SerializeField] private TextSetup _ballStoreNamingText;
        [SerializeField] private TextSetup _ballStoreMoneyText;
        [SerializeField] private TextSetup _ballStoreSkinPriceText;

        [Header("Site Store Menu")]
        [SerializeField] private ElementActivity _siteStoreMenuActivity;
        [SerializeField] private ElementActivity _siteStoreSelectedActivity;
        [SerializeField] private ElementActivity _siteStoreBoughtActivity;
        [SerializeField] private ElementActivity _siteStoreVideoActivity;
        [SerializeField] private ClickedCallback _siteStoreNextButton;
        [SerializeField] private ClickedCallback _siteStoreBackButton;
        [SerializeField] private ClickedCallback _siteStoreSelectedButton;
        [SerializeField] private ClickedCallback _siteStoreBoughtButton;
        [SerializeField] private ClickedCallback _siteStoreVideoButton;
        [SerializeField] private ClickedCallback _siteStoreMenuButton;
        [SerializeField] private TextSetup _siteStoreNamingText;
        [SerializeField] private TextSetup _siteStoreMoneyText;
        [SerializeField] private TextSetup _siteStoreSkinPriceText;

        [Header("Extralife Menu")]
        [SerializeField] private ElementActivity _extralifeMenuActivity;
        [SerializeField] private ClickedCallback _extralifeButton;
        [SerializeField] private ClickedCallback _extralifeCancelButton;

        [Header("End Menu")]
        [SerializeField] private ElementActivity _endMenuActivity;

        [Header("Subend Menu")]
        [SerializeField] private ElementActivity _subendMenuActivity;
        [SerializeField] private ClickedCallback _subendMenuHomeButton;
        [SerializeField] private ClickedCallback _subendMenuRestartButton;

        [Header("Speedometr Reward")]
        [SerializeField] private TextSetup _speedomentRewardmoneyText;
        [SerializeField] private ClickedCallback _stopSpeedometrButton;

        public override void InstallBindings()
        {
            BindMainMenu();
            BindSettingsMenu();
            BindGameplayMenu();
            BindPauseMenu();
            BindBallStoreMenu();
            BindSiteStoreMenu();
            BindExtralifeMenu();
            BindEndMenu();
            BindSubendMenu();
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
                .Bind<TextSetup>()
                .WithId(GameConstants.UiGameplayScoreCounterText)
                .FromInstance(_gameplayCounterText)
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
                .Bind<MatchScoreCounter>()
                .WithId(GameConstants.MatchScoreCounter)
                .AsCached();

            Container
                .BindInterfacesTo<MatchScoreCounter>()
                .AsCached();

            Container
                .Bind<EachElementActivityArray>()
                .WithId(GameConstants.HealthBarElementArray)
                .FromInstance(_iconHearth)
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<HealthBar>()
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
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiBallStoreSelectedActivity)
                .FromInstance(_ballStoreSelectedActivity)
                .AsCached();

            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiBallStoreBoughtActivity)
                .FromInstance(_ballStoreBoughtActivity)
                .AsCached();

            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiBallStoreVideoActivity)
                .FromInstance(_ballStoreVideoActivity)
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
                .WithId(GameConstants.UiBallStoreBoughtButton)
                .FromInstance(_ballStoreBoughtButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiBallStoreVideoButton)
                .FromInstance(_ballStoreVideoButton)
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
                .FromInstance(_ballStoreMoneyText)
                .AsCached();

            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.UiBallStoreSkinPriceText)
                .FromInstance(_ballStoreSkinPriceText)
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
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiSiteStoreSelectedActivity)
                .FromInstance(_siteStoreSelectedActivity)
                .AsCached();

            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiSiteStoreBoughtActivity)
                .FromInstance(_siteStoreBoughtActivity)
                .AsCached();

            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiSiteStoreVideoActivity)
                .FromInstance(_siteStoreVideoActivity)
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
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiSiteStoreBoughtButton)
                .FromInstance(_siteStoreBoughtButton)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiSiteStoreVideoButton)
                .FromInstance(_siteStoreVideoButton)
                .AsCached();

            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.UiSiteStoreNamingText)
                .FromInstance(_siteStoreNamingText)
                .AsCached();

            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.UiSiteStoreMoneyText)
                .FromInstance(_siteStoreMoneyText)
                .AsCached();

            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.UiSiteStoreSkinPriceText)
                .FromInstance(_siteStoreSkinPriceText)
                .AsCached();

            Container
                .Bind<IMenuActivity>()
                .WithId(GameConstants.UiSiteStoreMenu)
                .To<SiteStoreMenu>()
                .AsCached();

            Container
              .BindInterfacesAndSelfTo<SiteStoreMenu>()
              .AsCached()
              .NonLazy();

        }

        private void BindExtralifeMenu()
        {
            Container
                 .Bind<ElementActivity>()
                 .WithId(GameConstants.UiExtralifeMenuActivity)
                 .FromInstance(_extralifeMenuActivity)
                 .AsCached();

            Container
                 .Bind<ClickedCallback>()
                 .WithId(GameConstants.UiExtralifeButton)
                 .FromInstance(_extralifeButton)
                 .AsCached();

            Container
                 .Bind<ClickedCallback>()
                 .WithId(GameConstants.UiCancelExtralifeButton)
                 .FromInstance(_extralifeCancelButton)
                 .AsCached();

            Container
                .Bind<IMenuActivity>()
                .WithId(GameConstants.UiExtralifeMenu)
                .To<ExtralifeMenu>()
                .AsCached();

            Container
              .BindInterfacesAndSelfTo<ExtralifeMenu>()
              .AsCached()
              .NonLazy();
        }

        private void BindEndMenu()
        {
            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiEndActivity)
                .FromInstance(_endMenuActivity)
                .AsCached();

            Container
                .Bind<IMenuActivity>()
                .WithId(GameConstants.UiEndMenu)
                .To<EndMenu>()
                .AsCached();
        }

        private void BindSubendMenu()
        {
            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiSubendActivity)
                .FromInstance(_subendMenuActivity)
                .AsCached();

            Container
                .Bind<IMenuActivity>()
                .WithId(GameConstants.UiSubendMenu)
                .To<SubendMenu>()
                .AsCached();

            Container
                 .Bind<ClickedCallback>()
                 .WithId(GameConstants.UiSubendHomeButton)
                 .FromInstance(_subendMenuHomeButton)
                 .AsCached();

            Container
                 .Bind<ClickedCallback>()
                 .WithId(GameConstants.UiSubendRestartButton)
                 .FromInstance(_subendMenuRestartButton)
                 .AsCached();

            Container
                  .BindInterfacesAndSelfTo<SubendMenu>()
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
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonStopSpeedometr)
                .FromInstance(_stopSpeedometrButton)
                .AsCached();
        }
    }
}