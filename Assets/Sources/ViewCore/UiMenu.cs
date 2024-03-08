using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public abstract class UiMenu : IUiMenuActivity
    {
        protected readonly SignalBus SignalBus;
        private readonly ElementActivity _activity;

        public UiMenu(SignalBus signalBus, ElementActivity activity)
        {
            SignalBus = signalBus;
            _activity = activity;
        }

        public virtual void Show()
        {
            _activity.Show();
        }

        public virtual void Hide()
        {
            _activity.Hide();
        }
    }
}