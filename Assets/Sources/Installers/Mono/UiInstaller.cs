using Basketball_YG.Config;
using Basketball_YG.ViewCore;
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
        [SerializeField] private ElementActivity _timerActivity;
        [SerializeField] private Timer _timer;

        [Header("Pause Menu")]
        [SerializeField] private ElementActivity _pauseMenuActivity;
        [SerializeField] private ClickedCallback _closePauseMenuButton;

        public override void InstallBindings()
        {
            BindMainMenu();
            BindSettingsMenu();
            BindGameplayMenu();
            BindPauseMenu();
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
                .Bind<IUiMenuActivity>()
                .WithId(GameConstants.UiMainMenu)
                .To<UiMainMenu>()
                .AsCached();

            Container
                .BindInterfacesTo<UiMainMenu>()
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
                .Bind<IUiMenuActivity>()
                .WithId(GameConstants.UiSettingsMenu)
                .To<UiSettingsMenu>()
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<UiSettingsMenu>()
                .AsCached()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<VolumeSettings>()
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
                .Bind<IUiMenuActivity>()
                .WithId(GameConstants.UiGameplayMenu)
                .To<UiGameplayMenu>()
                .AsCached();

            Container
                .BindInterfacesTo<UiGameplayMenu>()
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
                .Bind<IUiMenuActivity>()
                .WithId(GameConstants.UiPauseMenu)
                .To<UiPauseMenu>()
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<UiPauseMenu>()
                .AsCached()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PauseOptions>()
                .AsCached()
                .NonLazy();
        }
    }
}