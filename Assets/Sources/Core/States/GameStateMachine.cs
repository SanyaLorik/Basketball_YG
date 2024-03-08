using Basketball_YG.Config;
using System;
using System.Collections.Generic;
using Zenject;

namespace Basketball_YG.Core
{
    public class GameStateMachine : IInitializable, IDisposable
    {
        private readonly IDictionary<Type, IState> _states;

        public GameStateMachine(
             [InjectOptional(Optional = true, Id = GameConstants.StateMainMenu)] IState mainMenu,
             [InjectOptional(Optional = true, Id = GameConstants.StateGameplay)] IState stateGameplay,
             [InjectOptional(Optional = true, Id = GameConstants.StateEnd)] IState end)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(MainMenuState)] = mainMenu,
                [typeof(GameplayState)] = stateGameplay,
                [typeof(EndState)] = end
            };
        }

        public void Initialize()
        {
            IState mainStage = _states[typeof(MainMenuState)];

            mainStage.OnFinised += OnSwitch;
            _states[typeof(GameplayState)].OnFinised += OnSwitch;
            _states[typeof(EndState)].OnFinised += OnSwitch;

            mainStage.Enable();
        }

        public void Dispose()
        {
            _states[typeof(MainMenuState)].OnFinised -= OnSwitch;
            _states[typeof(GameplayState)].OnFinised -= OnSwitch;
            _states[typeof(EndState)].OnFinised -= OnSwitch;
        }

        private void OnSwitch(IState current, Type next)
        {
            current.Disable();

            if (_states.TryGetValue(next, out IState nextState) == false)
                throw new KeyNotFoundException($"{next} is not found!");

            nextState.Enable();
        }
    }
}