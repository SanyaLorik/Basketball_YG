using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class UiSettingsMenu : UiMenu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _close;

        private readonly SignalBus _signalBus;

        public UiSettingsMenu(
            [InjectOptional(Optional = true, Id = GameConstants.UiSettingsMenuElementActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonCloseSettingsMenu)]
            ClickedCallback close,
            SignalBus signalBus) : base(activity)
        {
            _close = close;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _close.AddListner(OnClose);
        }

        public void Dispose()
        {
            _close.RemoveListener(OnClose);
        }

        private void OnClose()
        {
            _signalBus.Fire(new ActivitySettingsSignal(false));
        }
    }
}