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
        private readonly VelocityModel _model;

        public BallMovement(BallConfig config, VelocityModel model)
        {
            _config = config;
            _model = model;
        }

        public event Action OnHitted;
        public event Action OnMissed;

        public void Rebound(CollisionData data)
        {
            if (CanBound(data.Normal) == false)
                return;

            float height = GetHeight(data.CollisionType);
            Vector3 velocity = Calculate(height);
            _model.SetVelocity(velocity);
        }

        private bool CanBound(Vector3 normal)
        {
            throw new NotImplementedException();
        }

        private float GetHeight(CollisionType type) => type switch
        {
            CollisionType.Platform => _config.HeightPlatform,
            CollisionType.Hoopbase => _config.HeightHoopbase,
            _ => throw new NotImplementedException(),
        };

        private Vector3 Calculate(float height)
        {
            throw new NotImplementedException();
        }
    }
}