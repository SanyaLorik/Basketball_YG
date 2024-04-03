using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Counter;
using Basketball_YG.Mediator;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class SubendMenu : Menu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _stopButton;
        private readonly ClickedCallback _homeButton;
        private readonly ClickedCallback _restartButton;
        private readonly RewardSpeedometr _speedometr;
        private readonly TextSetup _countText;
        private readonly MatchScoreCounter _matchScore;

        public SubendMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiSubendActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonStopSpeedometr)]
            ClickedCallback stopButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiSubendHomeButton)]
            ClickedCallback homeButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiSubendRestartButton)]
            ClickedCallback restartButton,
            RewardSpeedometr speedometr,
            [InjectOptional(Optional = true, Id = GameConstants.UiSubendCounText)]
            TextSetup countText,
            MatchScoreCounter matchScore) : base(signalBus, activity)
        {
            _stopButton = stopButton;
            _speedometr = speedometr;
            _homeButton = homeButton;
            _restartButton = restartButton;
            _countText = countText;
            _matchScore = matchScore;
        }

        public void Initialize()
        {
            _stopButton.AddListner(OnStopRewardSpeedometr);
            _homeButton.AddListner(OnReturnToMainMenu);
            _restartButton.AddListner(OnRestart);
        }

        public void Dispose()
        {
            _stopButton.RemoveListener(OnStopRewardSpeedometr);
        }

        public override void Show()
        {
            base.Show();

            _countText.SetText(_matchScore.LastCount.ToString());
            _speedometr.ReturToInitialPosition();
            _speedometr.StartArrow();
        }

        public override void Hide()
        {
            base.Hide();

            _speedometr.StopArrow();
        }

        private void OnStopRewardSpeedometr()
        {
            _speedometr.StopArrow();
        }

        private void OnReturnToMainMenu()
        {
            SignalBus.Fire(new StateSignal(typeof(MainMenuState)));
        }

        private void OnRestart()
        {
            SignalBus.Fire(new StateSignal(typeof(GameplayState)));
        }
    }
}