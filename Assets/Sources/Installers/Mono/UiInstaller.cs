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
        [SerializeField] private ClickedCallback _startMath;
        [SerializeField] private ClickedCallback _skinStore;
        [SerializeField] private ClickedCallback _siteStore;
        [SerializeField] private ClickedCallback _settingsOpener;
        [SerializeField] private ClickedCallback _gameSharing;
        [SerializeField] private TextSetup _scoreMain;
        [SerializeField] private TextSetup _moneyMain;
        [SerializeField] private ElementActivity _mainMenuActivity;

        [Header("Settings Menu")]
        [SerializeField] private ClickedCallback _closeSettingsMenu;
        [SerializeField] private ElementActivity _settingsMenuActivity;

        [Header("Gameplay Menu")]
        [SerializeField] private ElementActivity _gameplayMenuActivity;

        public override void InstallBindings()
        {
            BindMainMenu();
            BindSettingsMenu();
            BindGameplayMenu();
        }

        private void BindMainMenu()
        {
            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonStartMath)
                .FromInstance(_startMath)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonBallStore)
                .FromInstance(_skinStore)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonSiteStore)
                .FromInstance(_siteStore)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonSettingsOpener)
                .FromInstance(_settingsOpener)
                .AsCached();

            Container
                .Bind<ClickedCallback>()
                .WithId(GameConstants.UiButtonGameSharing)
                .FromInstance(_gameSharing)
                .AsCached();

            Container
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiMainMenuElementActivity)
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
                .FromInstance(_closeSettingsMenu)
                .AsCached();

            Container
              .Bind<ElementActivity>()
              .WithId(GameConstants.UiSettingsMenuElementActivity)
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
                .Bind<ElementActivity>()
                .WithId(GameConstants.UiGameplayMenuElementActivity)
                .FromInstance(_gameplayMenuActivity)
                .AsCached();

            Container
                .Bind<IUiMenuActivity>()
                .WithId(GameConstants.UiGameplayMenu)
                .To<UiGameplayMenu>()
                .AsCached();

            Container
                .BindInterfacesTo<UiGameplayMenu>()
                .AsCached();
        }
    }
}