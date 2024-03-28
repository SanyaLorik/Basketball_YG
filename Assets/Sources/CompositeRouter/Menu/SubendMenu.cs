using Basketball_YG.Config;
using Basketball_YG.Core;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class SubendMenu : Menu
    {
        private readonly RewardSpeedometr _speedometr;

        public SubendMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiSubendActivity)]
            ElementActivity activity,
            RewardSpeedometr speedometr) : base(signalBus, activity)
        {
            _speedometr = speedometr;
        }

        public override void Hide()
        {
            base.Hide();
            _speedometr.ReturToInitialPosition();
            _speedometr.StartArrow();
        }
    }
}