using Basketball_YG.Config;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class EndMenu : Menu, IInitializable, IDisposable
    {
        public EndMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiEndActivity)]
            ElementActivity activity) : base(signalBus, activity)
        {
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}