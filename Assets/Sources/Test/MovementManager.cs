using Basketball_YG.Mediator;
using Basketball_YG.Model.Signal;
using Zenject;

namespace Basketball_YG.Test
{
    public class MovementManager : IInitializable
    {
        private SignalBus _signalBus;

        public MovementManager(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Fire(new StateSignal(typeof(GameplayState)));
        }
    }
}