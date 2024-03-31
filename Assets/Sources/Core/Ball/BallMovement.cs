using Basketball_YG.Config;
using Basketball_YG.Model;
using Basketball_YG.Wrapper;
using Cysharp.Threading.Tasks;
using SanyaBeer.Additional;
using System;
using System.Threading;
using UnityEngine;

namespace Basketball_YG.Core
{
    public class BallMovement : IDisposable
    {
        private readonly MovingPositionModel _model;
        private readonly BoundPointsCalcualor _boundCalcualor;
        private readonly RangeValues _range;

        private CancellationTokenSource _tokenSource;
        private bool _isPaused = false;

        public BallMovement(MovingPositionModel model, BoundPointsCalcualor boundCalcualor, RangeValues range)
        {
            _model = model;
            _boundCalcualor = boundCalcualor;
            _range = range;
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        public void Rebound(CollisionData data)
        {
            _tokenSource?.Cancel();

            PathSet pathSet = data;
            RunPath(pathSet);
        }

        public void RunPath(PathSet pathSet)
        {
            if (pathSet.Direction != DirectionBoundType.NoChanching)
                _model.Direction = pathSet.Direction.Value;

            if (pathSet.Final.HasValue == false)
                pathSet.SetFinal(GetFinalPoint(pathSet.Initial.Value));

            _tokenSource = new CancellationTokenSource();
            FollowPath(pathSet, _tokenSource.Token).Forget();
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Unpause()
        {
            _isPaused = false;
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

                _model?.SetPosition(position);

                float evaluatedSpeed = pathSet.Speed.Evaluate(ratio);
                extendedTime += Time.deltaTime * evaluatedSpeed;

                await UniTask.Yield(cancellationToken: token);

                if (_isPaused == true)
                    await UniTask.WaitWhile(() => _isPaused == true);
            }
            while (extendedTime < pathSet.Duration && token.IsCancellationRequested == false);
        }

        private Vector3 GetFinalPoint(Vector3 initial)
        {
            BoundPointType type = CalculateByPlatform(initial);
            return _boundCalcualor.CalculateByPosition(_model.Position, _model.Direction, type);
        }

        private BoundPointType CalculateByPlatform(Vector3 initial)
        {
            float distance = _range.ToX - _range.FromX;
            float distanceNear = distance - (1 - GameConstants.RatioNear) * distance;
            float distanceCentre = distance - (1 - GameConstants.RatioCentre) * distance;
            float initialX = Mathf.Abs(initial.x - _range.ToX);
            /*
            Debug.Log($"distance: {distance}\n" +
                $"distanceNear: {distanceNear}\n" +
                $"distanceCentre: {distanceCentre}\n" +
                $"initialX: {initialX}\n");
            */
            if (_model.Direction == DirectionBoundType.Right)
            {
                if (initialX < distanceNear)
                    return BoundPointType.Farther;

                if (initialX < distanceCentre)
                    return BoundPointType.Middle;

                return BoundPointType.Near;
            }
            else
            {
                if (initialX > distanceCentre)
                    return BoundPointType.Farther;

                if (initialX < distanceNear)
                    return BoundPointType.Near;

                return BoundPointType.Middle;
            }
        }
    }
}