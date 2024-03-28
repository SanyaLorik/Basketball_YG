using Basketball_YG.Model.Signal;
using System;
using Zenject;

namespace Basketball_YG.Core
{
    public class BallDistributer : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly BallFactory _factory;
        private readonly BallLauncher _launcher;
        private readonly BoundPoints _bounds;

        private const int TOTAL_COUNT_BALLS = 3;
        private int _current = 0;

        public BallDistributer(BallFactory factory, BallLauncher launcher, BoundPoints bounds, SignalBus signalBus)
        {
            _factory = factory;
            _launcher = launcher;
            _bounds = bounds;
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
            Distribute();
        }

        private void Distribute()
        {
            Ball ball = _factory.Create(BallType.Normal);
            _launcher.Launch(ball);
        }

        private void OnAddBall()
        {
            /*
            if (_current > TOTAL_COUNT_BALLS)
                return;

            _current++;
            */
            Distribute();
        }
    }
}