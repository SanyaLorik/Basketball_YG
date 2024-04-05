using Basketball_YG.Animation;
using Basketball_YG.Config;
using Basketball_YG.Model;
using Zenject;

namespace Basketball_YG.Core
{
    public class BallSkinSelector : SkinSelector
    {
        public BallSkinSelector(
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinSelectingModel)] SkinSelectingModel model, 
            NotificationPopup notificationPopup) : base(model, notificationPopup)
        {
        }
    }
}