using Basketball_YG.Config;
using System;

namespace Basketball_YG.Core
{
    public abstract class BallMovement : IBallMovement
    {
        protected readonly BallConfig Config;

        protected BallMovement(BallConfig config)
        {
            Config = config;
        }

        public Action OnHitted { set => throw new NotImplementedException(); }

        public Action OnMissed { set => throw new NotImplementedException(); }

        public void Tick()
        {
            throw new NotImplementedException();
        }
    }
}