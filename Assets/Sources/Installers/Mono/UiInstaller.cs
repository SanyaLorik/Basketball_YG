using Basketball_YG.Config;
using Basketball_YG.View.Ui;
using SanyaBeer.Meta;
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
        [SerializeField] private TextSetup _scoreMain;
        [SerializeField] private TextSetup _moneyMain;
        [SerializeField] private ElementActivity _mainMenuActivity;

        [Header("Main Menu")]
        [SerializeField] private ElementActivity _gameplayMenuActivity;

        public override void InstallBindings()
        {
            BindMainMenu();
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