using Basketball_YG.Data;
using SanyaBeer.Meta;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Basketball_YG.View
{
    public abstract class SkinSelectingView
    {
        private readonly TextSetup _naming;
        private readonly TextSetup _price;
        private readonly ElementActivity _selectedButtonActivity;
        private readonly ElementActivity _boughtButtonActivity;
        private readonly ElementActivity _videoButtonActivity;

        private readonly Dictionary<TradeType, ElementActivity> _activities;

        public SkinSelectingView(TextSetup naming, TextSetup price, ElementActivity selectedButtonActivity, ElementActivity boughtButtonActivity, ElementActivity videoButtonActivity)
        {
            _naming = naming;
            _price = price;
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

        public void SetName(string name)
        {
            _naming.SetText(name);
        }

        public void SetPrice(string price)
        {
            _price.SetText(price);
        }

        public void HidePrice()
        {
            UnityEngine.Debug.Log("Hide Price!");
        }
    }
}