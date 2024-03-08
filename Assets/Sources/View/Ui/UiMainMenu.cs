using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.View.Ui
{
    public class UiMainMenu : UiMenu
    {
        private readonly ClickedCallback _startMath;
        private readonly ClickedCallback _skinStore;
        private readonly ClickedCallback _locationStore;

        public UiMainMenu(
            [InjectOptional(Optional = true, Id = GameConstants.UiMainMenuElementActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonStartMath)]
            ClickedCallback startMath,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonSkinStore)]
            ClickedCallback skinStore,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonSiteStore)]
            ClickedCallback locationStore) : base(activity)
        {
            _startMath = startMath;
            _skinStore = skinStore;
            _locationStore = locationStore;
        }
    }

}