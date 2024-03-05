using Basketball_YG.Config;
using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using Zenject;

namespace Basketball_YG.Core
{
    public class GameStateMachine
    {
        private readonly IDictionary<Type, IState> _states;

        public GameStateMachine(
             [InjectOptional(Optional = true, Id = GameConstants.StateMainMenu)] IState mainMenu,
             [InjectOptional(Optional = true, Id = GameConstants.StateGameplay)] IState stateGameplay,
             [InjectOptional(Optional = true, Id = GameConstants.StateEnd)] IState end)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(MainStage)] = mainMenu,
                [typeof(GameplayState)] = stateGameplay,
                [typeof(EndState)] = end
            };

            mainMenu.OnFinised += OnSwitch;
            stateGameplay.OnFinised += OnSwitch;
            end.OnFinised += OnSwitch;
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