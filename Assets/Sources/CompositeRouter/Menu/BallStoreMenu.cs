using Basketball_YG.Config;
using Basketball_YG.Core;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class BallStoreMenu : StoreMenu
    {
        public BallStoreMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreNextButton)]
            ClickedCallback nextButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreBackButton)]
            ClickedCallback backButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreSelectedButton)]
            ClickedCallback selectedButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreBoughtButton)]
            ClickedCallback boughtButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreVideoButton)]
            ClickedCallback videoButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreMenuButton)]
            ClickedCallback menuButton,
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinSelector)]
            SkinSelector skinSelector) : 
            base(signalBus, activity, nextButton, backButton, selectedButton, boughtButton, videoButton, menuButton, skinSelector)
        {
        }
    }
}