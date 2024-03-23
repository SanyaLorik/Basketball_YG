using Basketball_YG.Config;
using Basketball_YG.Model;
using Basketball_YG.Wrapper;
using System;
using UnityEngine;

namespace Basketball_YG.Core
{
    public class BallMovement
    {
        private readonly BallConfig _config;
        private readonly MovingPositionModel _model;

        public BallMovement(BallConfig config, MovingPositionModel model)
        {
            _config = config;
            _model = model;
        }

        public void Rebound(CollisionData data)
        {
            if (CanBound(data.TouchPoint) == false)
                return;
        }

        public void RunPath()
        {

        }

        private bool CanBound(Vector3 normal)
        {
            throw new NotImplementedException();
        }
    }
}