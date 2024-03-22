using Basketball_YG.Core;
using Basketball_YG.Model;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Wrapper
{
    public class BallWrapperFactory : PlaceholderFactory<BallType, BallWrapper>
    {
        private readonly DiContainer _container;
        private readonly BallDictionary _balls;

        public BallWrapperFactory(DiContainer container, BallDictionary balls)
        {
            _container = container;
            _balls = balls;
        }

        public override BallWrapper Create(BallType type)
        {
            BallWrapper prefab = _balls.GetPrefabSkin(type);


            return null;
        }
    }
}