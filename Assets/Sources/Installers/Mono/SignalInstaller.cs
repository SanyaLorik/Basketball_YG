using Basketball_YG.Model.Signal;
using Zenject;

namespace Basketball_YG.Installer
{
    public class SignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            BindScore();
        }

        private void BindScore()
        {
            Container
                .DeclareSignal<ScoreSignal>()
                .OptionalSubscriber();
        }
    }
}