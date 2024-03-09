using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class UiSettingsMenu : UiShortMenu
    {
        public UiSettingsMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiSettingsMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonCloseSettingsMenu)]
            ClickedCallback close) : base(signalBus, activity, close)
        {

        }

        protected override void OnClose()
        {
            SignalBus.Fire(new ActivitySettingsSignal(false));
        }
    }
}