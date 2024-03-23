using Basketball_YG.Config;
using Basketball_YG.Model;
using Basketball_YG.Wrapper;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace Basketball_YG.Core
{
    public class BallMovement
    {
        private readonly MovingPositionModel _model;

        public BallMovement(MovingPositionModel model)
        {
            _model = model;
        }

        public void Rebound(CollisionData data)
        {
            if (CanBound(data.TouchPoint) == false)
                return;
        }

        public void RunPath(PathSet pathSet)
        {
            FollowPath(pathSet).Forget();
        }

        private async UniTaskVoid FollowPath(PathSet pathSet)
        {
            float extendedTime = 0;

            do
            {
                float ratio = extendedTime / pathSet.Duration;
                float evaluatedPosition = pathSet.Curve.Evaluate(ratio);
                Vector3 position = Vector3.Lerp(pathSet.Initial, pathSet.Final, ratio);
                position.y += evaluatedPosition * pathSet.Height;

                _model.SetPosition(position);

                float evaluatedSpeed = pathSet.Speed.Evaluate(ratio);
                extendedTime += Time.deltaTime * evaluatedSpeed;
                Debug.Log(extendedTime);
                await UniTask.Yield();
            }
            while (extendedTime < pathSet.Duration);
        }

        private bool CanBound(Vector3 normal)
        {
            throw new NotImplementedException();
        }
    }
}