using Basketball_YG.Core;
using Basketball_YG.Model;
using Zenject;

namespace Basketball_YG.Wrapper
{
    public class BallWrapperFactory : PlaceholderFactory<BallType, BallWrapper>
    {
        private readonly BallDictionary _balls;

        public BallWrapperFactory(BallDictionary balls)
        {
            _balls = balls;
        }

        public override BallWrapper Create(BallType type)
        {
            return _balls.GetPrefabSkin(type);
        }
    }
}