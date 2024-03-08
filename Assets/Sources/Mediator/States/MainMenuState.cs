using Basketball_YG.Config;
using Basketball_YG.ViewCore;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Mediator
{
    public class MainMenuState : State
    {
        private readonly IUiMenuActivity _uiMainMenuActivity;

        public MainMenuState(
            [InjectOptional(Optional = true, Id = GameConstants.UiMainMenu)]
            IUiMenuActivity uiMainMenuActivity)
        {
            _uiMainMenuActivity = uiMainMenuActivity;
        }

        public override void Enable()
        {
            Debug.LogWarning("Enable. There is logic handler MainMenuState here!");
        }

        public override void Disable()
        {
            _uiMainMenuActivity.Hide();
        }
    }
}