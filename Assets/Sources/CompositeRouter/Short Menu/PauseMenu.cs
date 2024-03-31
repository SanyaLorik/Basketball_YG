using Basketball_YG.Config;
using Basketball_YG.Installer;
using Basketball_YG.Mediator;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class PauseMenu : ShortMenu
    {
        private readonly ClickedCallback _continueButton;
        private readonly ClickedCallback _restartButton;

        public PauseMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiPauseMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonClosePauseMenu)]
            ClickedCallback close,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonContinuePauseMenu)]
            ClickedCallback continueButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonRestartPauseMenu)]
            ClickedCallback restartButton) : base(signalBus, activity, close)
        {
            _continueButton = continueButton;
            _restartButton = restartButton;
        }

        public override void Initialize()
        {
            base.Initialize();

            _continueButton.AddListner(OnClose);
            _restartButton.AddListner(OnRestart);
        }

        public override void Dispose()
        {
            base.Dispose();

            _continueButton.RemoveListener(OnClose);
            _restartButton.AddListner(OnRestart);
        }

        protected override void OnClose()
        {
            base.OnClose();
            SignalBus.Fire(new PauseSingal(PauseSingal.PauseType.Unpause));
        }

        private void OnRestart()
        {
            OnClose();
            SignalBus.Fire(new StateSignal(typeof(GameplayState)));
        }
    }
}