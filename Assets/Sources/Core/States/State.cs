using System;

namespace Basketball_YG.Core
{
    public abstract class State : IState
    {
        public event Action<IState, Type> OnFinised;

        public abstract void Disable();

        public abstract void Enable();
    }
}