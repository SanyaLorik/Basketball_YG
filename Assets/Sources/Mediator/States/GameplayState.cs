using Basketball_YG.CompositeRoot;
using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Counter;
using Basketball_YG.Input;
using Cysharp.Threading.Tasks;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.Mediator
{
    public class GameplayState : State
    {
        private readonly IMenuActivity _uiGameplayMenuActivity;
        private readonly IActivityInputService _activityInput;
        private readonly ElementActivityArray _prestartActivities;
        private readonly ElementActivity _timerActivity;
        private readonly Timer _timer;
        private readonly BallDistributer _ballDistributer;
        private readonly HealthBar _healthBar;
        private readonly MatchScoreCounter _scoreCounter;
        private readonly PlatformMovement _platformMovement;

        public GameplayState(
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayMenu)]
            IMenuActivity uiGameplayMenuActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayTimerActivity)]
            ElementActivity timerActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayPrestartMatchActivities)]
            ElementActivityArray prestartActivities,
            IActivityInputService activityInput,
            Timer timer,
            BallDistributer ballDistributer,
            HealthBar healthBar,
            [InjectOptional(Optional = true, Id = GameConstants.MatchScoreCounter)]
            MatchScoreCounter scoreCounter,
            PlatformMovement platformMovement)
        {
            _uiGameplayMenuActivity = uiGameplayMenuActivity;
            _timerActivity = timerActivity;
            _prestartActivities = prestartActivities;
            _activityInput = activityInput;
            _timer = timer;
            _ballDistributer = ballDistributer;
            _healthBar = healthBar;
            _scoreCounter = scoreCounter;
            _platformMovement = platformMovement;
        }

        public override void Enable()
        {
            UniTask.Create(async () =>
            {
                _uiGameplayMenuActivity.Show();
                _activityInput.Disable();
                _timerActivity.Show();
                _prestartActivities.Hide();

                await _timer.StartTimer();

                _activityInput.Enable();
                _timerActivity.Hide();
                _prestartActivities.Show();

                _ballDistributer.Start();
            });
        }

        public override void Disable()
        {
            _uiGameplayMenuActivity.Hide();
            _prestartActivities.Hide();
            _activityInput.Disable();
            _ballDistributer.Stop();
            _healthBar.Reload();
            _scoreCounter.Reload();
        }
    }
}