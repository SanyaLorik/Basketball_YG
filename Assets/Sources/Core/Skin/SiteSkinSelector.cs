using Basketball_YG.Animation;
using Basketball_YG.Model;

namespace Basketball_YG.Core
{
    public class SiteSkinSelector : SkinSelector
    {
        public SiteSkinSelector(
            SiteSelectingModel model,
            NotificationPopup notificationPopup) : base(model, notificationPopup)
        {
        }
    }
}