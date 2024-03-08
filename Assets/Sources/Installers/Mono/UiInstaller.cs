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
        [SerializeField] private TextSetup _score;
        [SerializeField] private ElementActivity _mainMenuActivity;

        public override void InstallBindings()
        {
            BindMainMenu();
            BindScoreText();
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
                .WithId(GameConstants.UiButtonSkinStore)
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
        }

        private void BindScoreText()
        {
            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.UiMainMenuScoreText)
                .FromInstance(_score)
                .AsCached();
        }
    }
}