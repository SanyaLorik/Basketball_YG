using Basketball_YG.Config;
using Basketball_YG.Model;
using Zenject;

namespace Basketball_YG.Core
{
    public class SiteSkinSelector : SkinSelector
    {
        public SiteSkinSelector(
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinSelectingModel)] SkinSelectingModel model) : base(model)
        {
        }
    }
}