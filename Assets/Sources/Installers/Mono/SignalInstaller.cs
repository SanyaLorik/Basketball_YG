using Basketball_YG.Model.Signal;
using Zenject;

namespace Basketball_YG.Installer
{
    public class SignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            BindSwitchState();
            BindSettings();
            BindPause();
            BindBall();
            BindSite();
        }

        private void BindSwitchState()
        {
            Container
                .DeclareSignal<StateSignal>()
                .OptionalSubscriber();
        }

        private void BindSettings()
        {
            Container
                .DeclareSignal<ActivitySettingsSignal>()
                .OptionalSubscriber();
        }

        private void BindPause()
        {
            Container
                .DeclareSignal<ActivityPauseSignal>()
                .OptionalSubscriber();
        }

        private void BindBall()
        {
            Container
                .DeclareSignal<ActivityBallStoreSignal>()
                .OptionalSubscriber();
        }

        private void BindSite()
        {
            Container
                .DeclareSignal<ActivitySiteStoreSignal>()
                .OptionalSubscriber();
        }
    }
}