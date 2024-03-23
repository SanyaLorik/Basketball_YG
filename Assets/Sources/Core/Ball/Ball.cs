using Basketball_YG.Wrapper;
using SanyaBeer.Event;
using System;
using Zenject;

namespace Basketball_YG.Core
{
    public class Ball : IInitializable, IDisposable
    {
        private readonly IEventObserver<CollisionData> _collider;
        private readonly BallMovement _movement;

        public Ball(IEventObserver<CollisionData> ballWrapper, BallMovement movement)
        {
            _collider = ballWrapper;
            _movement = movement;
        }

        public void Initialize()
        {
            _collider.OnPerfomed += OnRebound;
        }

        public void Dispose()
        {
            _collider.OnPerfomed -= OnRebound;
        }

        public void RunPatch(PathSet pathSet)
        {
            _movement.RunPath(pathSet);
        }

        private void OnRebound(CollisionData data)
        {
            _movement.Rebound(data);
        }
    }
}