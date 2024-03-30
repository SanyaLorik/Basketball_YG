using Basketball_YG.Model.Signal;
using Basketball_YG.Wrapper;
using System;
using Zenject;

namespace Basketball_YG.Core
{
    public class Ball : IInitializable, IDisposable
    {
        private readonly BallWrapper _wrapper;
        private readonly BallMovement _movement;
        private readonly SignalBus _signalBus;

        public Ball(BallWrapper ballWrapper, BallMovement movement, SignalBus signalBus)
        {
            _wrapper = ballWrapper;
            _movement = movement;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _wrapper.OnCollision += OnRebound;
            _wrapper.OnScored += OnNotifyScore;
            _wrapper.OnMissed += OnNotifyMiss;
        }

        public void Dispose()
        {
            _wrapper.OnCollision -= OnRebound;
            _wrapper.OnScored -= OnNotifyScore;
            _wrapper.OnMissed -= OnNotifyMiss;
        }

        public void RunPatch(PathSet pathSet)
        {
            _movement.RunPath(pathSet);
        }

        public void Destroy()
        {
            _movement.Dispose();
            _wrapper.Destroy();
        }

        private void OnRebound(CollisionData data)
        {
            _movement.Rebound(data);
        }

        private void OnNotifyScore()
        {
            const int test_score = 10;
            _signalBus.Fire(new ScoreSignal(test_score));
        }

        private void OnNotifyMiss()
        {
            _signalBus.Fire(new MissBallSignal());
        }
    }
}