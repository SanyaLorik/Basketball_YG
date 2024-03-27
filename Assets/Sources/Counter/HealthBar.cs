using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.Counter
{
    public class HealthBar : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly EachElementActivityArray _hearts;

        public HealthBar(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.HealthBar)]
            EachElementActivityArray activityArray)
        {
            _signalBus = signalBus;
            _hearts = activityArray;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<MissBallSignal>(OnUpdateHealth);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<MissBallSignal>(OnUpdateHealth);
        }

        private void OnUpdateHealth()
        {
            _hearts.HideOne();
        }
    }
}