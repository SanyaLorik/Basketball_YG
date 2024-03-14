using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class UiBallStoreMenu : UiMenu, IInitializable, IDisposable
    {
        public UiBallStoreMenu(SignalBus signalBus, ElementActivity activity) : base(signalBus, activity)
        {
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}