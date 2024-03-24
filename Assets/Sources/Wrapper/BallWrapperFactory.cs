using Basketball_YG.Core;
using Basketball_YG.Model;
using Zenject;

namespace Basketball_YG.Wrapper
{
    public class BallWrapperFactory : PlaceholderFactory<BallType, BallWrapper>
    {
        private readonly BallDictionary _balls;
        private readonly BallSpawner _ballSpawner;

        public BallWrapperFactory(BallDictionary balls, BallSpawner ballSpawner)
        {
            _balls = balls;
            _ballSpawner = ballSpawner;
        }

        public override BallWrapper Create(BallType type)
        {
            return _ballSpawner.Spawn(_balls.GetPrefabSkin(type));
        }
    }
}