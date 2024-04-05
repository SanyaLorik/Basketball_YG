using Basketball_YG.Animation;
using Basketball_YG.Model;

namespace Basketball_YG.Core
{
    public class BallSkinSelector : SkinSelector
    {
        public BallSkinSelector(
            BallSelectingModel model, 
            NotificationPopup notificationPopup) : base(model, notificationPopup)
        {
        }
    }
}