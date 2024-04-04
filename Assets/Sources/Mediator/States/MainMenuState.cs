using Basketball_YG.CompositeRoot;
using Basketball_YG.Config;
using Basketball_YG.Volume;
using Zenject;

namespace Basketball_YG.Mediator
{

    public class MainMenuState : State
    {
        private readonly IMenuActivity _uiMainMenuActivity;
        private readonly VolumeManagement _volumeManagement;

        public MainMenuState(
            [InjectOptional(Optional = true, Id = GameConstants.UiMainMenu)]
            IMenuActivity uiMainMenuActivity, 
            VolumeManagement volumeManagement)
        {
            _uiMainMenuActivity = uiMainMenuActivity;
            _volumeManagement = volumeManagement;
        }

        public override void Enable()
        {
            _uiMainMenuActivity.Show();
            _volumeManagement.PlayMusic(VolumeType.MainMusic);
        }

        public override void Disable()
        {
            _uiMainMenuActivity.Hide();
        }
    }
}