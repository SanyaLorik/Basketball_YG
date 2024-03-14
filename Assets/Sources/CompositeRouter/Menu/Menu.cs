using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public abstract class Menu : IMenuActivity
    {
        protected readonly SignalBus SignalBus;
        private readonly ElementActivity _activity;

        public Menu(SignalBus signalBus, ElementActivity activity)
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