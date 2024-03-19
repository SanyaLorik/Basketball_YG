using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.View
{
    public class SiteSelectingView : SkinSelectingView
    {
        public SiteSelectingView(
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreNamingText)]
            TextSetup naming,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreSkinPriceText)]
            TextSetup price,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreSelectedActivity)]
            ElementActivity selectedButtonActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreBoughtActivity)]
            ElementActivity boughtButtonActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreVideoActivity)]
            ElementActivity videoButtonActivity) : base(naming, price, selectedButtonActivity, boughtButtonActivity, videoButtonActivity)
        {

        }
    }
}