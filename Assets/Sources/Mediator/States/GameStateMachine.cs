using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Mediator
{
    public class GameStateMachine : IInitializable, IDisposable
    {
        private readonly IDictionary<Type, IState> _states;
        private IState _current;

        private readonly SignalBus _signalBus;

        public GameStateMachine(
             [InjectOptional(Optional = true, Id = GameConstants.StateMainMenu)] IState mainMenu,
             [InjectOptional(Optional = true, Id = GameConstants.StateGameplay)] IState stateGameplay,
             [InjectOptional(Optional = true, Id = GameConstants.StateEnd)] IState end,
             SignalBus signalBus)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(MainMenuState)] = mainMenu,
                [typeof(GameplayState)] = stateGameplay,
                [typeof(EndState)] = end
            };

            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<StateSignal>(OnSwitch);

            _current = _states[typeof(MainMenuState)];
            _current.Enable();
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<StateSignal>(OnSwitch);
        }

        private void OnSwitch(StateSignal next)
        {
            if (next.State == _current.GetType())
            {
                Debug.Log($"Reload state {_current}.");
                _current.Disable();
                _current.Enable();

                return;
            }

            Debug.Log($"Switch from {_current} state to {next.State}.");
            _current.Disable();

            if (_states.TryGetValue(next.State, out IState nextState) == false)
                throw new KeyNotFoundException($"{next.State} is not found!");

            _current = nextState;
            nextState.Enable();
        }
    } 
}