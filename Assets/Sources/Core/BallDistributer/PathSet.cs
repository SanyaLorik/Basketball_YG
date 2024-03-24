using Basketball_YG.Wrapper;
using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Basketball_YG.Core
{
    public class PathSet
    {
        public readonly AnimationCurve Curve;
        public readonly AnimationCurve Speed;

        public Vector3? Initial { get; private set; }
        public Vector3? Final { get; private set; }
        public DirectionBoundType? Direction { get; private set; }
        public float? Duration { get; private set; }
        public float? Height { get; private set; }

        public PathSet(AnimationCurve curve, AnimationCurve speed)
        {
            Curve = curve;
            Speed = speed;
        }

        public PathSet SetInitial(Vector3 initial)
        {
            Set(() => Initial.HasValue, () => Initial = initial);
            return this;
        }

        public PathSet SetFinal(Vector3 final)
        {
            Set(() => Final.HasValue, () => Final = final);
            return this;
        }

        public PathSet SetDirection(DirectionBoundType direction)
        {
            Set(() => Direction.HasValue, () => Direction = direction);
            return this;
        }

        public PathSet SetDuration(float duration)
        {
            Set(() => Duration.HasValue, () => Duration = duration);
            return this;
        }

        public PathSet SetHeight(float height)
        {
            Set(() => Height.HasValue, () => Height = height);
            return this;
        }

        private void Set(Func<bool> predicate, Action setter)
        {
            if (predicate.Invoke() == true)
                throw new Exception($"Reciever {setter} has already value!");

            setter.Invoke();
        }

        public static implicit operator PathSet(CollisionData data)
        {
            PathSet pathSet = new(data.Curve, data.Speed);
            pathSet
                .SetInitial(data.TouchPoint)
                .SetDirection(data.Direction)
                .SetDuration(data.Duration)
                .SetHeight(data.Height);

            return pathSet;
        }
    }
}