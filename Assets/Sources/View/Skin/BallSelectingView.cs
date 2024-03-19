using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.View
{
    public class BallSelectingView : SkinSelectingView
    {
        public BallSelectingView(
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreNamingText)]
            TextSetup naming,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreSkinPriceText)]
            TextSetup price,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreSelectedActivity)]
            ElementActivity selectedButtonActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreBoughtActivity)]
            ElementActivity boughtButtonActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreVideoActivity)]
            ElementActivity videoButtonActivity) : base(naming, price, selectedButtonActivity, boughtButtonActivity, videoButtonActivity)
        {

        }
    }
}