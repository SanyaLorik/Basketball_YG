using Basketball_YG.Config;
using Basketball_YG.Mediator;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.Counter
{
    public class HealthBar : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly EachElementActivityArray _heartsIcons;

        private const int TotalHeart = 3;
        private int _heartCounter = TotalHeart;

        public HealthBar(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.HealthBarElementArray)]
            EachElementActivityArray heartsIcons)
        {
            _signalBus = signalBus;
            _heartsIcons = heartsIcons;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<MissBallSignal>(OnUpdateHealth);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<MissBallSignal>(OnUpdateHealth);
        }

        public void Reload()
        {
            _heartCounter = TotalHeart;
            _heartsIcons.ShowAll();
        }

        private void OnUpdateHealth()
        {
            if (_heartCounter <= 0)
                return;

            _heartsIcons.HideOne();
            _heartCounter--;

            if (_heartCounter <= 0)
            {
                _signalBus.Fire(new NoneHeartSignal());
                _signalBus.Fire(new StateSignal(typeof(EndState)));
            }
        }
    }
}