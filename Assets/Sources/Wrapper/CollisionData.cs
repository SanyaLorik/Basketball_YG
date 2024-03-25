using Basketball_YG.Core;
using UnityEngine;

namespace Basketball_YG.Wrapper
{
    public struct CollisionData
    {
        public readonly AnimationCurve Curve;
        public readonly AnimationCurve Speed;
        public readonly Vector3 TouchPoint;
        public readonly Vector3? Final;
        public readonly DirectionBoundType Direction;
        public readonly float Duration;
        public readonly float Height;

        public CollisionData(AnimationCurve curve, AnimationCurve speed, Vector3 touchPoint, Vector3? final, DirectionBoundType direction, float duration, float height)
        {
            Curve = curve;
            Speed = speed;
            TouchPoint = touchPoint;
            Final = final;
            Direction = direction;
            Duration = duration;
            Height = height;
        }
    }
}