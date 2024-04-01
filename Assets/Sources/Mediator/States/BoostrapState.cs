using Basketball_YG.Model.Signal;
using Basketball_YG.Sdk;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Basketball_YG.Mediator
{
    public class BoostrapState : State
    {
        private readonly SignalBus _signalBus;
        private readonly IContectionStatus _contectionStatus;

        public BoostrapState(SignalBus signalBus, IContectionStatus contectionStatus)
        {
            _signalBus = signalBus;
            _contectionStatus = contectionStatus;
        }
        public override void Enable()
        {
            UniTask.Create(async () =>
            {
                await UniTask.WaitWhile(() => _contectionStatus.IsConnected == false);

                _signalBus.Fire(new StateSignal(typeof(MainMenuState)));
            });
        }

        public override void Disable()
        {
            throw new System.NotImplementedException();
        }
    }
}