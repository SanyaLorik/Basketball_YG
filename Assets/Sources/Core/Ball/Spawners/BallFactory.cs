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
        private readonly BoundPointsCalcualor _calcualor;

        public BallFactory(DiContainer container, BallWrapperFactory wrapperFactory, BallSpawner ballSpawner, BoundPointsCalcualor calcualor)
        {
            _container = container;
            _wrapperFactory = wrapperFactory;
            _ballSpawner = ballSpawner;
            _calcualor = calcualor;
        }

        public override Ball Create(BallType type)
        {
            BallWrapper prefab = _wrapperFactory.Create(type);
            BallWrapper wrapper = _ballSpawner.Spawn(prefab);
            MovingPositionView view = new(wrapper.Rigidbody);
            MovingPositionModel model = new(view);
            BallMovement movement = new(model, _calcualor);

            _container.Inject(movement);

            Ball ball = new (wrapper, movement);

            return ball;
        }
    }
}