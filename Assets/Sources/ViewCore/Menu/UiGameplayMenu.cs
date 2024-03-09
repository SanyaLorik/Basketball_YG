using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class UiGameplayMenu : UiMenu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _pauseOpener;

        public UiGameplayMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonGameplayPauseOpener)]
            ClickedCallback pauseOpener) : base(signalBus, activity)
        {
            _pauseOpener = pauseOpener;
        }

        public void Initialize()
        {
            _pauseOpener.AddListner(OnPause);
        }

        public void Dispose()
        {
            _pauseOpener.RemoveListener(OnPause);
        }

        private void OnPause()
        {
            SignalBus.Fire(new ActivityPauseSignal(true));
        }
    }
}