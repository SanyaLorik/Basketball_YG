namespace Basketball_YG.Core
{
    public class BallDistributer
    {
        private readonly BallFactory _factory;
        private readonly BallLauncher _launcher;
        private readonly BoundPoints _bounds;

        public BallDistributer(BallFactory factory, BallLauncher launcher, BoundPoints bounds)
        {
            _factory = factory;
            _launcher = launcher;
            _bounds = bounds;
        }

        public void Start()
        {
            Ball ball = _factory.Create(BallType.Normal);
            _launcher.Launch(ball);
        }
    }
}