using UnityEngine;

namespace Basketball_YG.Core
{
    public readonly struct PathSet
    {
        public readonly AnimationCurve Curve;
        public readonly AnimationCurve Speed;
        public readonly Vector3 Initial;
        public readonly Vector3 Final;
        public readonly float Duration;
        public readonly float Height;

        public PathSet(AnimationCurve curve, AnimationCurve speed, Vector3 initial, Vector3 final, float duration, float height)
        {
            Curve = curve;
            Speed = speed;
            Initial = initial;
            Final = final;
            Duration = duration;
            Height = height;
        }
    }
}