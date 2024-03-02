using Basketball_YG.Config;
using Basketball_YG.Meta;
using Basketball_YG.View.Ui;
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
        [SerializeField] private ClickedCallback _locationStore;
        [SerializeField] private TextSetup _score;

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
                .WithId(GameConstants.UiButtonLocationStore)
                .FromInstance(_locationStore)
                .AsCached();

            Container
                .Bind<UiMainMenuAction>()
                .WithId(GameConstants.UiMainMenuAction)
                .AsCached();
        }

        private void BindScoreText()
        {
            Container
                .Bind<TextSetup>()
                .WithId(GameConstants.UiScoreText)
                .FromInstance(_score)
                .AsCached();
        }
    }
}