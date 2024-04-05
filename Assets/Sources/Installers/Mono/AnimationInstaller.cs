using Basketball_YG.Animation;
using Zenject;

namespace Basketball_YG.Installer
{
    public class AnimationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindNotificationPopup();
        }

        private void BindNotificationPopup()
        {
            Container
                .Bind<NotificationPopup>()
                .AsCached();
        }
    }
}