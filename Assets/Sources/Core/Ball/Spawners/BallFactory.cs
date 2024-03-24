using Basketball_YG.Mediator;
using Basketball_YG.Model;
using Basketball_YG.View;
using Basketball_YG.Wrapper;
using Zenject;

namespace Basketball_YG.Core
{
    public class BallFactory : PlaceholderFactory<BallType, Ball>
    {
        private readonly SafeDisposableManagement _disposableManagement;
        private readonly BallWrapperFactory _wrapperFactory;
        private readonly BoundPointsCalcualor _calcualor;

        public BallFactory(SafeDisposableManagement disposableManagement, BallWrapperFactory wrapperFactory, BoundPointsCalcualor calcualor)
        {
            _disposableManagement = disposableManagement;
            _wrapperFactory = wrapperFactory;
            _calcualor = calcualor;
        }

        public override Ball Create(BallType type)
        {
            BallWrapper wrapper = _wrapperFactory.Create(type);
            MovingPositionView view = new(wrapper.Rigidbody);
            MovingPositionModel model = new(view);
            BallMovement movement = new(model, _calcualor);
            Ball ball = new(wrapper, movement);

            ball.Initialize();
            _disposableManagement.AddDisposable(ball, movement);

            return ball;
        }
    }
}