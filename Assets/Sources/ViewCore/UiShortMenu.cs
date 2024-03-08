using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public abstract class UiShortMenu : UiMenu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _close;

        public UiShortMenu(SignalBus signalBus, ElementActivity activity, ClickedCallback close) : base(signalBus, activity)
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

        protected abstract void OnClose();
    }
}