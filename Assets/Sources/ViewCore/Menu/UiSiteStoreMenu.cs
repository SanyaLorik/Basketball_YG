using Basketball_YG.Config;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class UiSiteStoreMenu : UiMenu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _nextButton;
        private readonly ClickedCallback _backButton;
        private readonly ClickedCallback _selectedButton;
        private readonly ClickedCallback _menuButton;
        private readonly TextSetup _namingText;
        private readonly TextSetup _moneyText;

        public UiSiteStoreMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreNextButton)]
            ClickedCallback nextButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreBackButton)]
            ClickedCallback backButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreSelectedButton)]
            ClickedCallback selectedButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreMenuButton)]
            ClickedCallback menuButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreNamingText)]
            TextSetup namingText,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreMoneyText)]
            TextSetup moneyText) : base(signalBus, activity)
        {
            _nextButton = nextButton;
            _backButton = backButton;
            _selectedButton = selectedButton;
            _menuButton = menuButton;
            _namingText = namingText;
            _moneyText = moneyText;
        }

        public void Initialize()
        {
            _nextButton.AddListner(OnNextSkin);
            _backButton.AddListner(OnBackSkin);
            _selectedButton.AddListner(OnSelectSkin);
            _menuButton.AddListner(OnMenuSkin);
        }

        public void Dispose()
        {
            _nextButton.RemoveListener(OnNextSkin);
            _backButton.RemoveListener(OnBackSkin);
            _selectedButton.RemoveListener(OnSelectSkin);
            _menuButton.RemoveListener(OnMenuSkin);
        }

        private void OnNextSkin()
        {
            throw new NotImplementedException();
        }

        private void OnBackSkin()
        {
            throw new NotImplementedException();
        }

        private void OnSelectSkin()
        {
            throw new NotImplementedException();
        }

        private void OnMenuSkin()
        {
            throw new NotImplementedException();
        }
    }
}