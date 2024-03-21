using System;
using System.Collections;
using System.Collections.Generic;
using Zenject;

namespace Basketball_YG.Core
{
    public abstract class Ball 
    {
        private readonly IBallMovement _movement;

        public Ball(IBallMovement movement)
        {

        }
    }

    public interface IBall
    {
        event Action OnHitted;
    }

    public interface IBall<out T> : IBall
    {
        new event Action<T> OnHitted;
    
    
    }
}