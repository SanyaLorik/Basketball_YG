﻿using Basketball_YG.Config;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class UiGameplayMenu : UiMenu, IInitializable, IDisposable
    {
        public UiGameplayMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayMenuElementActivity)]
            ElementActivity activity) : base(signalBus, activity)
        {

        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}