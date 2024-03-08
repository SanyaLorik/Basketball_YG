using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using System;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class PauseOptions : IInitializable, IDisposable
    {
        private IUiMenuActivity _uiMenuActivity;
        private readonly SignalBus _signalBus;

        public PauseOptions(
            [InjectOptional(Optional = true, Id = GameConstants.UiPauseMenu)]
            IUiMenuActivity uiMenuActivity,
            SignalBus signalBus)
        {
            _uiMenuActivity = uiMenuActivity;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ActivityPauseSignal>(OnOpenMenu);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ActivityPauseSignal>(OnOpenMenu);
        }

        private void OnOpenMenu(ActivityPauseSignal activity)
        {
            if (activity.IsOpening == true)
                _uiMenuActivity.Show();
            else
                _uiMenuActivity.Hide();
        }
    }
}