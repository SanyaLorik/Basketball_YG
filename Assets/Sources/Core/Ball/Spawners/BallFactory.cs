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
        private readonly BoundPointsCalcualor _calcualor;

        public BallFactory(DiContainer container, BallWrapperFactory wrapperFactory, BoundPointsCalcualor calcualor)
        {
            _container = container;
            _wrapperFactory = wrapperFactory;
            _calcualor = calcualor;
        }

        public override Ball Create(BallType type)
        {
            BallWrapper wrapper = _wrapperFactory.Create(type);
            MovingPositionView view = new(wrapper.Rigidbody);
            MovingPositionModel model = new(view);

            BallMovement movement = new(model, _calcualor);
            _container.BindInterfacesAndSelfTo<BallMovement>().FromInstance(movement).NonLazy();

            Ball ball = new(wrapper, movement);
            _container.BindInterfacesAndSelfTo<Ball>().FromInstance(ball).NonLazy();

            return ball;
        }
    }
}