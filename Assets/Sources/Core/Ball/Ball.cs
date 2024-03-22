using Basketball_YG.Wrapper;
using System;
using Zenject;

namespace Basketball_YG.Core
{
    public abstract class Ball : IInitializable, IDisposable
    {
        private readonly BallWrapper _ballWrapper;
        private readonly BallMovement _movement;

        public Ball(BallWrapper ballWrapper, BallMovement movement)
        {
            _ballWrapper = ballWrapper;
            _movement = movement;
        }

        public void Initialize()
        {
            _ballWrapper.OnCollision += OnRebound;
        }

        public void Dispose()
        {
            _ballWrapper.OnCollision -= OnRebound;
        }

        private void OnRebound(CollisionData data)
        {
            _movement.Rebound(data);
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