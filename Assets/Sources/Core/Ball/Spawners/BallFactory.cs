using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Basketball_YG.Core
{
    public class BallFactory : PlaceholderFactory<BallType, IBall>
    {
        private readonly DiContainer _container;
        private readonly IDictionary<BallType, GameObject> _balls;

        public BallFactory(DiContainer container, IDictionary<BallType, GameObject> balls)
        {
            _container = container;
            _balls = balls;
        }

        public override IBall Create(BallType type)
        {
            Assert.IsTrue(_balls.ContainsKey(type));

            ///var 

            return null;
        }
    }
}