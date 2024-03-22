using System;

namespace SanyaBeer.Event
{
    public interface IEventObserver<T>
    {
        event Action<T> OnPerfomed;
    }
}