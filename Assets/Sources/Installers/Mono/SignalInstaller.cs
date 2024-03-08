﻿using Basketball_YG.Model.Signal;
using Zenject;

namespace Basketball_YG.Installer
{
    public class SignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            BindSwitchState();
            BindSettings();
            BindPause();
        }

        private void BindSwitchState()
        {
            Container
                .DeclareSignal<StateSignal>()
                .OptionalSubscriber();
        }

        private void BindSettings()
        {
            Container
                .DeclareSignal<ActivitySettingsSignal>()
                .OptionalSubscriber();
        }

        private void BindPause()
        {
            Container
                .DeclareSignal<ActivityPauseSignal>()
                .OptionalSubscriber();
        }
    }
}