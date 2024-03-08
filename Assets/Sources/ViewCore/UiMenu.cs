using SanyaBeer.Meta;

namespace Basketball_YG.ViewCore
{
    public abstract class UiMenu : IUiMenuActivity
    {
        private readonly ElementActivity _activity;

        public UiMenu(ElementActivity activity)
        {
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