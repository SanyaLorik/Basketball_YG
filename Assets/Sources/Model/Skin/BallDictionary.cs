using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Sdk;
using Basketball_YG.Wrapper;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Model
{
    public class BallDictionary
    {
        private readonly PrefabBallsConfig _prefabBalls;
        private readonly ICurrentSkinProvider _currentProvider;

        public BallDictionary(
            PrefabBallsConfig prefabBalls,
            [Inject(Optional = true, Id = GameConstants.BallSkinStoreSdkProvider)]
            ICurrentSkinProvider currentProvider)
        {
            _prefabBalls = prefabBalls;
            _currentProvider = currentProvider;
        }

        public BallWrapper GetPrefabSkin(BallType type)
        {
            return _prefabBalls.Prefabs.FirstOrDefault(i => i.Id == _currentProvider.Id).Ball;
        }
    }
}