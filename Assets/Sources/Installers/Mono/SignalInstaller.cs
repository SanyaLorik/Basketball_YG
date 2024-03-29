﻿using Basketball_YG.Model.Signal;
using System;
using Zenject;

namespace Basketball_YG.Installer
{
    public class SignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            BindSwitchState();
            BindScoreState();
            BindMissedBall();
            BindNoneHeartBall();
        }

        private void BindSwitchState()
        {
            Container
                .DeclareSignal<StateSignal>()
                .OptionalSubscriber();
        }

        private void BindScoreState()
        {
            Container
                .DeclareSignal<ScoreSignal>()
                .OptionalSubscriber();
        }

        private void BindMissedBall()
        {
            Container
                .DeclareSignal<MissBallSignal>()
                .OptionalSubscriber();
        }

        private void BindNoneHeartBall()
        {
            Container
                .DeclareSignal<NoneHeartSignal>()
                .OptionalSubscriber();
        }
    }
}