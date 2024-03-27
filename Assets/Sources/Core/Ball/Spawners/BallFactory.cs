using Basketball_YG.Config;
using Basketball_YG.Mediator;
using Basketball_YG.Model;
using Basketball_YG.View;
using Basketball_YG.Wrapper;
using SanyaBeer.Additional;
using Zenject;

namespace Basketball_YG.Core
{
    public class BallFactory : PlaceholderFactory<BallType, Ball>
    {
        private readonly SafeDisposableManagement _disposableManagement;
        private readonly BallWrapperFactory _wrapperFactory;
        private readonly BoundPointsCalcualor _calcualor;
        private readonly RangeValues _range;
        private readonly SignalBus _signalBus;

        public BallFactory(SafeDisposableManagement disposableManagement, BallWrapperFactory wrapperFactory, BoundPointsCalcualor calcualor,
            [Inject(Optional = true, Id = GameConstants.PlatformSurfaceRangeValues)]
            RangeValues range, SignalBus signalBus)
        {
            _disposableManagement = disposableManagement;
            _wrapperFactory = wrapperFactory;
            _calcualor = calcualor;
            _range = range;
            _signalBus = signalBus;
        }

        public override Ball Create(BallType type)
        {
            BallWrapper wrapper = _wrapperFactory.Create(type);
            MovingPositionView view = new(wrapper.Rigidbody);
            MovingPositionModel model = new(view);
            BallMovement movement = new(model, _calcualor, _range);
            Ball ball = new(wrapper, movement, _signalBus);

            ball.Initialize();
            _disposableManagement.AddDisposable(ball, movement);

            return ball;
        }
    }
}