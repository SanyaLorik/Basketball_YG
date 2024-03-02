using Basketball_YG.Config;
using Basketball_YG.Meta;
using Zenject;

namespace Basketball_YG.View.Ui
{
    public class UiMainMenuAction
    {
        private readonly ClickedCallback _startMath;
        private readonly ClickedCallback _skinStore;
        private readonly ClickedCallback _locationStore;

        public UiMainMenuAction(
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonStartMath)] 
            ClickedCallback startMath,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonSkinStore)]
            ClickedCallback skinStore,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonLocationStore)]
            ClickedCallback locationStore)
        {
            _startMath = startMath;
            _skinStore = skinStore;
            _locationStore = locationStore;
        }
    }
}