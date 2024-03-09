using Basketball_YG.Config;
using Basketball_YG.Input;
using Basketball_YG.ViewCore;
using Cysharp.Threading.Tasks;
using SanyaBeer.Meta;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Mediator
{
    public class GameplayState : State
    {
        private readonly IUiMenuActivity _uiGameplayMenuActivity;
        private readonly IActivityInputService _activityInput;
        private readonly ElementActivity _timerActivity;
        private readonly Timer _timer;

        public GameplayState(
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayMenu)]
            IUiMenuActivity uiGameplayMenuActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayTimerActivity)]
            ElementActivity timerActivity,
            IActivityInputService activityInput,
            Timer timer)
        {
            _uiGameplayMenuActivity = uiGameplayMenuActivity;
            _timerActivity = timerActivity;
            _activityInput = activityInput;
            _timer = timer;
        }

        public override void Enable()
        {
            _uiGameplayMenuActivity.Show();

            UniTask.Create(async () =>
            {
                _activityInput.Disable();
                _timerActivity.Show();

                await _timer.StartTimer();

                _activityInput.Enable();
                _timerActivity.Hide();
            });
        }

        public override void Disable()
        {
            Debug.LogWarning("Enable. There is logic handler GameplayState here!");
        }
    }
}