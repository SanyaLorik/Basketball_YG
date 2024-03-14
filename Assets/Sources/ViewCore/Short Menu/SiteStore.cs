using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using System;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class SiteStore : IInitializable, IDisposable
    {
        private IUiMenuActivity _uiMenuActivity;
        private readonly SignalBus _signalBus;

        public SiteStore(
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreMenu)]
            IUiMenuActivity uiMenuActivity,
            SignalBus signalBus)
        {
            _uiMenuActivity = uiMenuActivity;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ActivitySiteStoreSignal>(OnOpenMenu);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ActivitySiteStoreSignal>(OnOpenMenu);
        }

        private void OnOpenMenu(ActivitySiteStoreSignal activity)
        {
            if (activity.IsOpening == true)
                _uiMenuActivity.Show();
            else
                _uiMenuActivity.Hide();
        }
    }
}