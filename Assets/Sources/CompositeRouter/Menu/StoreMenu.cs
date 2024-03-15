using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class StoreMenu : Menu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _nextButton;
        private readonly ClickedCallback _backButton;
        private readonly ClickedCallback _selectedButton;
        private readonly ClickedCallback _boughtButton;
        private readonly ClickedCallback _videoButton;
        private readonly ClickedCallback _menuButton;
        private readonly SkinSelector _skinSelector;

        public StoreMenu(
            SignalBus signalBus,
            ElementActivity activity,
            ClickedCallback nextButton,
            ClickedCallback backButton,
            ClickedCallback selectedButton,
            ClickedCallback boughtButton,
            ClickedCallback videoButton,
            ClickedCallback menuButton,
            SkinSelector skinSelector) : base(signalBus, activity)
        {
            _nextButton = nextButton;
            _backButton = backButton;
            _selectedButton = selectedButton;
            _menuButton = menuButton;
            _boughtButton = boughtButton;
            _videoButton = videoButton;
            _skinSelector = skinSelector;
        }

        public void Initialize()
        {
            _nextButton.AddListner(OnNextSkin);
            _backButton.AddListner(OnBackSkin);
            _selectedButton.AddListner(OnSelectSkin);
            _boughtButton.AddListner(OnBuyForMoney);
            _videoButton.AddListner(OnBuyForVideo);
            _menuButton.AddListner(OnBackToMenu);
        }

        public void Dispose()
        {
            _nextButton.RemoveListener(OnNextSkin);
            _backButton.RemoveListener(OnBackSkin);
            _selectedButton.RemoveListener(OnSelectSkin);
            _boughtButton.RemoveListener(OnBuyForMoney);
            _videoButton.RemoveListener(OnBuyForVideo);
            _menuButton.RemoveListener(OnBackToMenu);
        }

        private void OnNextSkin()
        {
            _skinSelector.Next();
        }

        private void OnBackSkin()
        {
            _skinSelector.Back();
        }

        private void OnSelectSkin()
        {
            _skinSelector.Select();
        }

        private void OnBuyForMoney()
        {
            _skinSelector.BuyForMoney();
        }

        private void OnBuyForVideo()
        {
            _skinSelector.BuyForVideo();
        }

        private void OnBackToMenu()
        {
            Hide();
        }
    }
}