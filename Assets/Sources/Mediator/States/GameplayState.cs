using Basketball_YG.CompositeRoot;
using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Input;
using Cysharp.Threading.Tasks;
using SanyaBeer.Meta;
using UnityEngine;
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

        public GameplayState(
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayMenu)]
            IMenuActivity uiGameplayMenuActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayTimerActivity)]
            ElementActivity timerActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayPrestartMatchActivities)]
            ElementActivityArray prestartActivities,
            IActivityInputService activityInput,
            Timer timer,
            BallDistributer ballDistributer)
        {
            _uiGameplayMenuActivity = uiGameplayMenuActivity;
            _timerActivity = timerActivity;
            _prestartActivities = prestartActivities;
            _activityInput = activityInput;
            _timer = timer;
            _ballDistributer = ballDistributer;
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
        }
    }
}