using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class SettingsMenu : ShortMenu
    {
        public SettingsMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiSettingsMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonCloseSettingsMenu)]
            ClickedCallback close) : base(signalBus, activity, close)
        {

        }
    }
}