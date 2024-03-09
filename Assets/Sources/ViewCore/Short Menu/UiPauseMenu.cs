using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class UiPauseMenu : UiShortMenu
    {
        public UiPauseMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiPauseMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonClosePauseMenu)]
            ClickedCallback close) : base(signalBus, activity, close)
        {

        }

        protected override void OnClose()
        {
            SignalBus.Fire(new ActivityPauseSignal(false));
        }
    }
}