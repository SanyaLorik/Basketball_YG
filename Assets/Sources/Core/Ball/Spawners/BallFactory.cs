using Basketball_YG.Wrapper;
using Zenject;

namespace Basketball_YG.Core
{
    public class BallFactory : PlaceholderFactory<BallType, Ball>
    {
        private readonly DiContainer _container;
        private readonly BallWrapperFactory _ballFactory;

        public BallFactory(DiContainer container, BallWrapperFactory ballFactory)
        {
            _container = container;
            _ballFactory = ballFactory;
        }

        public override Ball Create(BallType type)
        {
            BallWrapper prefab = _ballFactory.Create(type);
            

            return null;
        }
    }
}