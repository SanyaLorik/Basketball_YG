using System;

namespace Basketball_YG.Core
{
    public interface IState
    {
        event Action<IState, Type> OnFinised;

        void Enable();

        void Disable();
    }
}