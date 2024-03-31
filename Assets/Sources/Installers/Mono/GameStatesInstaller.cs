﻿using Basketball_YG.CompositeRoot;
using Basketball_YG.Config;
using Basketball_YG.Mediator;
using Zenject;

namespace Basketball_YG.Installer
{
    public class GameStatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMainMenuState();
            BindGameplayState();
            BindEndState();
            BindGameStateMachine();
        }

        private void BindMainMenuState()
        {
            Container
                .Bind<IState>()
                .WithId(GameConstants.StateMainMenu)
                .To<MainMenuState>()
                .AsCached();
        }

        private void BindGameplayState()
        {
            Container
                .Bind<IState>()
                .WithId(GameConstants.StateGameplay)
                .To<GameplayState>()
                .AsCached();

            Container
                .BindInterfacesTo<GameplayState>()
                .AsCached();
        }

        private void BindEndState()
        {
            Container
                .Bind<IState>()
                .WithId(GameConstants.StateEnd)
                .To<EndState>()
                .AsCached();
        }

        private void BindGameStateMachine()
        {
            Container
                .BindInterfacesTo<GameStateMachine>()
                .AsCached()
                .NonLazy();
        }
    }
}