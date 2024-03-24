using Basketball_YG.Config;
using SanyaBeer.Additional;

namespace Basketball_YG.Core
{
    public class BallLauncher
    {
        private readonly Cannon[] _cannons;
        private readonly BallLauncherConfig _config;
        private readonly BoundPointsCalcualor _calcualor;

        public BallLauncher(Cannon[] cannons, BallLauncherConfig config, BoundPointsCalcualor calcualor)
        {
            _cannons = cannons;
            _config = config;
            _calcualor = calcualor;
        }

        public void Launch(Ball ball)
        {
            Cannon cannon = _cannons.GetRandomElement();
            PathSet pathSet = new(_config.Curve, _config.Speed, cannon.LaunchPoint, _calcualor.CalculateByPosition(cannon.LaunchPoint, cannon.Direction), cannon.Direction, _config.Duration, _config.Height);
            ball.RunPatch(pathSet);
        }
    }
}