using Basketball_YG.Config;
using Basketball_YG.Core;
using Basketball_YG.Wrapper;

namespace Basketball_YG.Model
{
    public class BallDictionary
    {
        private readonly PrefabBallsConfig _prefabBalls;

        public BallDictionary(PrefabBallsConfig prefabBalls)
        {
            _prefabBalls = prefabBalls;
        }

        public BallWrapper GetPrefabSkin(BallType type)
        {
            return _prefabBalls.Prefabs[0].Ball;
        }
    }
}