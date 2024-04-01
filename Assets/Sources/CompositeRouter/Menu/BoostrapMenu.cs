using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class BoostrapMenu : Menu
    {
        public BoostrapMenu(SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiBoostrapMenuActivity)]
            ElementActivity activity) : base(signalBus, activity)
        {
        }
    }
}