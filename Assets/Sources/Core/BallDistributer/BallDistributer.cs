using Basketball_YG.Model.Signal;
using System;
using System.Collections.Generic;
using Zenject;

namespace Basketball_YG.Core
{
    public class BallDistributer : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly BallFactory _factory;
        private readonly BallLauncher _launcher;

        private readonly List<Ball> _balls = new();
        private bool _isDistributing = false;

        /*
        private const int TOTAL_COUNT_BALLS = 3;
        private int _current = 0; 
        */

        public BallDistributer(BallFactory factory, BallLauncher launcher, SignalBus signalBus)
        {
            _factory = factory;
            _launcher = launcher;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ScoreSignal>(OnAddBall);
            _signalBus.Subscribe<MissBallSignal>(OnAddBall);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ScoreSignal>(OnAddBall);
            _signalBus.Unsubscribe<MissBallSignal>(OnAddBall);
        }

        public void Start()
        {
            _isDistributing = true;
            Distribute();
        }

        public void Stop()
        {
            _isDistributing = false;
        }

        public void Pause()
        {
            foreach (var ball in _balls)
                ball.Pause();
        }

        public void Unpause()
        {
            foreach (var ball in _balls)
                ball.Unpause();
        }

        public void RemoveBalls()
        {
            for (int i = _balls.Count - 1; i >= 0; i--)
            {
                _balls[i].Destroy();
                _balls.RemoveAt(i);
            }
        }

        private void Distribute()
        {
            Ball ball = _factory.Create(BallType.Normal);
            ball.Hide();

            _launcher.Launch(ball);

            _balls.Add(ball);
            ball.Show();
        }

        private void OnAddBall()
        {
            if (_isDistributing == false) 
                return;

            Distribute();
        }
    }
}