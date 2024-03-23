using UnityEngine;

namespace Basketball_YG.Core
{
    public readonly struct PathSet
    {
        public readonly AnimationCurve Curve;
        public readonly AnimationCurve Speed;
        public readonly Vector3 Initial;
        public readonly Vector3 Final;

        public PathSet(AnimationCurve curve, AnimationCurve speed, Vector3 initial, Vector3 final)
        {
            Curve = curve;
            Speed = speed;
            Initial = initial;
            Final = final;
        }
    }
}