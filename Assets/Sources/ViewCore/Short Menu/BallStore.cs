using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using System;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class BallStore : IInitializable, IDisposable
    {
        private IUiMenuActivity _uiMenuActivity;
        private readonly SignalBus _signalBus;

        public BallStore(
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreMenu)]
            IUiMenuActivity uiMenuActivity,
            SignalBus signalBus)
        {
            _uiMenuActivity = uiMenuActivity;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ActivityBallStoreSignal>(OnOpenMenu);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ActivityBallStoreSignal>(OnOpenMenu);
        }

        private void OnOpenMenu(ActivityBallStoreSignal activity)
        {
            if (activity.IsOpening == true)
                _uiMenuActivity.Show();
            else
                _uiMenuActivity.Hide();
        }
    }
}