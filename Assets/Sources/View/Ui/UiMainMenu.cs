using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.View.Ui
{
    public class UiMainMenu : UiMenu, IInitializable, IDisposable
    {
        private readonly ClickedCallback _startMath;
        private readonly ClickedCallback _ballStore;
        private readonly ClickedCallback _siteStore;

        private readonly SignalBus _signalBus;

        public UiMainMenu(
            [InjectOptional(Optional = true, Id = GameConstants.UiMainMenuElementActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonStartMath)]
            ClickedCallback startMath,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonBallStore)]
            ClickedCallback ballStore,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonSiteStore)]
            ClickedCallback siteStore,
            SignalBus signalBus) : base(activity)
        {
            _startMath = startMath;
            _ballStore = ballStore;
            _siteStore = siteStore;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _startMath.AddListner(OnStartMath);
            _ballStore.AddListner(OnOpenBallStore);
            _siteStore.AddListner(OnOpenSiteStore);
        }

        public void Dispose()
        {
            _startMath.RemoveListener(OnStartMath);
            _ballStore.RemoveListener(OnOpenBallStore);
            _siteStore.RemoveListener(OnOpenSiteStore);
        }

        private void OnStartMath()
        {
            _signalBus.Fire(new StateSignal(typeof(GameplayState)));
        }

        private void OnOpenBallStore()
        {
            throw new NotImplementedException();
        }

        private void OnOpenSiteStore()
        {
            throw new NotImplementedException();
        }
    }
}