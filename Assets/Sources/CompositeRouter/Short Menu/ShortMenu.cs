using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public abstract class ShortMenu : Menu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _close;

        public ShortMenu(SignalBus signalBus, ElementActivity activity, ClickedCallback close) : base(signalBus, activity)
        {
            _close = close;
        }

        public void Initialize()
        {
            _close.AddListner(OnClose);
        }

        public void Dispose()
        {
            _close.RemoveListener(OnClose);
        }

        protected virtual void OnClose()
        {
            Hide();
        }
    }
}