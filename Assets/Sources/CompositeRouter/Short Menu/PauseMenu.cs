using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class PauseMenu : ShortMenu
    {
        public PauseMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiPauseMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonClosePauseMenu)]
            ClickedCallback close) : base(signalBus, activity, close)
        {

        }
    }
}