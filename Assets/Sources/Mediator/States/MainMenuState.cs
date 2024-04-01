using Basketball_YG.CompositeRoot;
using Basketball_YG.Config;
using Zenject;

namespace Basketball_YG.Mediator
{

    public class MainMenuState : State
    {
        private readonly IMenuActivity _uiMainMenuActivity;

        public MainMenuState(
            [InjectOptional(Optional = true, Id = GameConstants.UiMainMenu)]
            IMenuActivity uiMainMenuActivity)
        {
            _uiMainMenuActivity = uiMainMenuActivity;
        }

        public override void Enable()
        {
            _uiMainMenuActivity.Show();
        }

        public override void Disable()
        {
            _uiMainMenuActivity.Hide();
        }
    }
}