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
        private readonly BallWrapperFactory _wrapperFactory;
        private readonly BallSpawner _ballSpawner;

        public BallFactory(DiContainer container, BallWrapperFactory ballFactory, BallSpawner ballSpawner)
        {
            _container = container;
            _wrapperFactory = ballFactory;
            _ballSpawner = ballSpawner;
        }

        public override Ball Create(BallType type)
        {
            BallWrapper prefab = _wrapperFactory.Create(type);
            BallWrapper wrapper = _ballSpawner.Spawn(prefab);
            MovingPositionView view = new(wrapper.Rigidbody);
            MovingPositionModel model = new(view);
            BallMovement movement = new(model);

            _container.Inject(movement);

            Ball ball = new (wrapper, movement);

            return ball;
        }
    }
}