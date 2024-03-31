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

        public virtual void Initialize()
        {
            _close.AddListner(OnClose);
        }

        public virtual void Dispose()
        {
            _close.RemoveListener(OnClose);
        }

        protected virtual void OnClose()
        {
            Hide();
        }
    }
}