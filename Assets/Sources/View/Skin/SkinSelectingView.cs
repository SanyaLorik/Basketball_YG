using Basketball_YG.Config;
using Basketball_YG.Data;
using SanyaBeer.Meta;
using System.Collections.Generic;
using Zenject;

namespace Basketball_YG.View
{
    public abstract class SkinSelectingView
    {
        private readonly ElementActivity _selectedButtonActivity;
        private readonly ElementActivity _boughtButtonActivity;
        private readonly ElementActivity _videoButtonActivity;

        private readonly Dictionary<TradeType, ElementActivity> _activities;

        public SkinSelectingView(ElementActivity selectedButtonActivity, ElementActivity boughtButtonActivity, ElementActivity videoButtonActivity)
        {
            _selectedButtonActivity = selectedButtonActivity;
            _boughtButtonActivity = boughtButtonActivity;
            _videoButtonActivity = videoButtonActivity;

            _activities = new Dictionary<TradeType, ElementActivity>()
            {
                { TradeType.Bought, _selectedButtonActivity},
                { TradeType.SaleForMoney, _boughtButtonActivity},
                { TradeType.SaleForReward, _videoButtonActivity},
            };
        }

        public void ShowOnlyButtonByType(TradeType trade)
        {
            foreach (var activity in _activities)
            {
                if (activity.Key == trade)
                    activity.Value.Show();
                else
                    activity.Value.Hide();
            }
        }
    }

    public class BallSelectingView : SkinSelectingView
    {
        public BallSelectingView(
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreSelectedActivity)]
            ElementActivity selectedButtonActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreBoughtActivity)]
            ElementActivity boughtButtonActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreVideoActivity)]
            ElementActivity videoButtonActivity) : base(selectedButtonActivity, boughtButtonActivity, videoButtonActivity)
        {

        }
    }
    public class SiteSelectingView : SkinSelectingView
    {
        public SiteSelectingView(
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreSelectedActivity)]
            ElementActivity selectedButtonActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreBoughtActivity)]
            ElementActivity boughtButtonActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreVideoActivity)]
            ElementActivity videoButtonActivity) : base(selectedButtonActivity, boughtButtonActivity, videoButtonActivity)
        {

        }
    }
}