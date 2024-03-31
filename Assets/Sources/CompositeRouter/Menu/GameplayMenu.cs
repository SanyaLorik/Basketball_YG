using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class GameplayMenu : Menu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _pauseOpener;
        private readonly IMenuActivity _pauseMenu;

        public GameplayMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonGameplayPauseOpener)]
            ClickedCallback pauseOpener,
            [InjectOptional(Optional = true, Id = GameConstants.UiPauseMenu)]
            IMenuActivity pauseMenu) : base(signalBus, activity)
        {
            _pauseOpener = pauseOpener;
            _pauseMenu = pauseMenu;
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
            _pauseMenu.Show();
            SignalBus.Fire(new PauseSingal(PauseSingal.PauseType.Pause));
        }
    }
}