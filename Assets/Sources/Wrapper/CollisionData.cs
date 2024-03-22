using UnityEngine;

namespace Basketball_YG.Wrapper
{
    public readonly struct CollisionData
    {
        public readonly float Height;
        public readonly Vector3 TouchPoint;

        public CollisionData(float height, Vector3 touchPoint)
        {
            Height = height;
            TouchPoint = touchPoint;
        }
    }
}