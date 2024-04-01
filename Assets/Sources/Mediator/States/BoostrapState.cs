﻿using Basketball_YG.CompositeRoot;
using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using Basketball_YG.Sdk;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Basketball_YG.Mediator
{
    public class BoostrapState : State
    {
        private readonly SignalBus _signalBus;
        private readonly IContectionStatus _contectionStatus;
        private readonly IMenuActivity _boostrapMenu;

        public BoostrapState(SignalBus signalBus,
            IContectionStatus contectionStatus,
            [InjectOptional(Optional = true, Id = GameConstants.UiBoostrapMenu)]
            IMenuActivity boostrapMenu)
        {
            _signalBus = signalBus;
            _contectionStatus = contectionStatus;
            _boostrapMenu = boostrapMenu;
        }
        public override void Enable()
        {
            UniTask.Create(async () =>
            {
                await UniTask.WaitWhile(() => _contectionStatus.IsConnected == false);

                _signalBus.Fire(new StateSignal(typeof(MainMenuState)));
            });
        }

        public override void Disable()
        {
            _boostrapMenu.Hide();
        }
    }
}