using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class UiBallStoreMenu : UiMenu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _nextButton;
        private readonly ClickedCallback _backButton;
        private readonly ClickedCallback _selectedButton;
        private readonly ClickedCallback _menuButton;

        public UiBallStoreMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreNextButton)]
            ClickedCallback nextButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreBackButton)]
            ClickedCallback backButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreSelectedButton)]
            ClickedCallback selectedButton, 
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreMenuButton)]
            ClickedCallback menuButton) : base(signalBus, activity)
        {
            _nextButton = nextButton;
            _backButton = backButton;
            _selectedButton = selectedButton;
            _menuButton = menuButton;
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
            SignalBus.Fire(new ActivityBallStoreSignal(false));
        }
    }
}