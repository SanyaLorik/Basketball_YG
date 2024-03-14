using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class SiteStoreMenu : StoreMenu
    {
        public SiteStoreMenu(
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
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinSelector)]
            SkinSelector skinSelector) :
            base(signalBus, activity, nextButton, backButton, selectedButton, menuButton, skinSelector)
        {

        }
    }
}