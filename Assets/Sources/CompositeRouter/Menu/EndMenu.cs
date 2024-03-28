using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class EndMenu : Menu
    {
        public EndMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiEndActivity)]
            ElementActivity activity) : base(signalBus, activity)
        {
        }
    }
}