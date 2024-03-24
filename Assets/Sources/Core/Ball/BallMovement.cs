using Basketball_YG.Model;
using Basketball_YG.Wrapper;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace Basketball_YG.Core
{
    public class BallMovement : IDisposable
    {
        private readonly MovingPositionModel _model;
        private readonly BoundPointsCalcualor _boundCalcualor;

        private CancellationTokenSource _tokenSource;

        public BallMovement(MovingPositionModel model, BoundPointsCalcualor boundCalcualor)
        {
            _model = model;
            _boundCalcualor = boundCalcualor;
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public void Rebound(CollisionData data)
        {
            _tokenSource.Cancel();

            PathSet pathSet = data;

            if (pathSet.Final.HasValue == false)
                pathSet.SetFinal(GetFinalPoint());

            RunPath(pathSet);
        }

        public void RunPath(PathSet pathSet)
        {
            if (pathSet.Final.HasValue == false)
                pathSet.SetFinal(GetFinalPoint());

            _tokenSource = new CancellationTokenSource();
            FollowPath(pathSet, _tokenSource.Token).Forget();
        }

        private async UniTaskVoid FollowPath(PathSet pathSet, CancellationToken token)
        {
            float extendedTime = 0;

            do
            {
                float ratio = extendedTime / pathSet.Duration.Value;
                float evaluatedPosition = pathSet.Curve.Evaluate(ratio);
                Vector3 position = Vector3.Lerp(pathSet.Initial.Value, pathSet.Final.Value, ratio);
                position.y += evaluatedPosition * pathSet.Height.Value;

                _model.SetPosition(position);

                float evaluatedSpeed = pathSet.Speed.Evaluate(ratio);
                extendedTime += Time.deltaTime * evaluatedSpeed;

                await UniTask.Yield(cancellationToken: token);
            }
            while (extendedTime < pathSet.Duration && token.IsCancellationRequested == false);
        }

        private Vector3 GetFinalPoint()
        {
            throw new NotImplementedException();
        }
    }
}