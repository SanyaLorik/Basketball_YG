using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class UiSettingsMenu : UiMenu
    {
        public UiSettingsMenu(
            [InjectOptional(Optional = true, Id = GameConstants.UiSettingsMenuElementActivity)]
            ElementActivity activity) : base(activity)
        {

        }
    }
}