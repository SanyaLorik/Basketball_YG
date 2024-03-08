using Basketball_YG.Config;
using Basketball_YG.View.Ui;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Mediator
{
    public class GameplayState : State
    {
        private readonly IUiMenuActivity _uiGameplayMenuActivity;

        public GameplayState(
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayMenu)]
            IUiMenuActivity uiGameplayMenuActivity)
        {
            _uiGameplayMenuActivity = uiGameplayMenuActivity;
        }
        public override void Enable()
        {
            _uiGameplayMenuActivity.Show();
        }

        public override void Disable()
        {
            Debug.LogWarning("Enable. There is logic handler GameplayState here!");
        }
    }
}