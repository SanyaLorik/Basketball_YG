using Basketball_YG.Config;
using Basketball_YG.Model;
using Basketball_YG.View;
using Basketball_YG.Wrapper;
using Zenject;

namespace Basketball_YG.Core
{
    public class BallFactory : PlaceholderFactory<BallType, Ball>
    {
        private readonly DiContainer _container;
        private readonly BallWrapperFactory _ballFactory;
        private readonly BallSpawner _ballSpawner;
        private readonly BallConfig _ballConfig;

        public BallFactory(DiContainer container, BallWrapperFactory ballFactory, BallSpawner ballSpawner, BallConfig ballConfig)
        {
            _container = container;
            _ballFactory = ballFactory;
            _ballSpawner = ballSpawner;
            _ballConfig = ballConfig;
        }

        public override Ball Create(BallType type)
        {
            BallWrapper prefab = _ballFactory.Create(type);
            BallWrapper ballWrapper = _ballSpawner.Spawn(prefab);
            VelocityView velocityView = new (ballWrapper.Rigidbody);
            VelocityModel velocityModel = new (velocityView);
            BallMovement ballMovement = new BallMovement(_ballConfig, velocityModel);

            _container.Inject(ballMovement);

            Ball ball = new (ballWrapper, ballMovement);

            return ball;
        }
    }
}