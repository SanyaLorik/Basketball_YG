using Basketball_YG.Config;
using Basketball_YG.Mediator;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.CompositeRoot
{

    public class MainMenu : Menu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _startMath;
        private readonly ClickedCallback _ballStore;
        private readonly ClickedCallback _siteStore;
        private readonly ClickedCallback _settingsOpener;
        private readonly ClickedCallback _gameSharing;
        private readonly IMenuActivity _ballStoreMenu;
        private readonly IMenuActivity _siteStoreMenu;
        private readonly IMenuActivity _settingMenu;

        public MainMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiMainMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonStartMath)]
            ClickedCallback startMath,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonBallStore)]
            ClickedCallback ballStore,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonSiteStore)]
            ClickedCallback siteStore,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonSettingsOpener)]
            ClickedCallback settingsOpener,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonGameSharing)]
            ClickedCallback gameSharing,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreMenu)]
            IMenuActivity ballStoreMenu,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreMenu)]
            IMenuActivity siteStoreMenu,
            [InjectOptional(Optional = true, Id = GameConstants.UiSettingsMenu)]
            IMenuActivity settingMenu) : base(signalBus, activity)
        {
            _startMath = startMath;
            _ballStore = ballStore;
            _siteStore = siteStore;
            _settingsOpener = settingsOpener;
            _gameSharing = gameSharing;
            _ballStoreMenu = ballStoreMenu;
            _siteStoreMenu = siteStoreMenu;
            _settingMenu = settingMenu;
        }

        public void Initialize()
        {
            _startMath.AddListner(OnStartMath);
            _ballStore.AddListner(OnOpenBallStore);
            _siteStore.AddListner(OnOpenSiteStore);
            _settingsOpener.AddListner(OnOpenSettings);
            _gameSharing.AddListner(OnShareGame);
        }

        public void Dispose()
        {
            _startMath.RemoveListener(OnStartMath);
            _ballStore.RemoveListener(OnOpenBallStore);
            _siteStore.RemoveListener(OnOpenSiteStore);
            _settingsOpener.RemoveListener(OnOpenSettings);
            _gameSharing.RemoveListener(OnShareGame);
        }

        private void OnStartMath()
        {
            SignalBus.Fire(new StateSignal(typeof(GameplayState)));
        }

        private void OnOpenBallStore()
        {
            _ballStoreMenu.Show();
        }

        private void OnOpenSiteStore()
        {
            _siteStoreMenu.Show();
        }

        private void OnOpenSettings()
        {
            _settingMenu.Show();
        }

        private void OnShareGame()
        {
            throw new NotImplementedException();
        }
    }
}