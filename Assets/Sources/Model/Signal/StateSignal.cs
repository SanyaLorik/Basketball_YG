using System;

namespace Basketball_YG.Model.Signal
{
    public struct StateSignal
    {
        public readonly Type State;

        public StateSignal(Type state)
        {
            State = state;
        }
    }
}