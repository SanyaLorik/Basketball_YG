using Basketball_YG.Config;
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
        private readonly TextSetup _namingText;
        private readonly TextSetup _moneyText;

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
            ClickedCallback menuButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreNamingText)]
            TextSetup namingText,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreMoneyText)]
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
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}