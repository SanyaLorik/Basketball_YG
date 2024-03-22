using UnityEngine;

namespace Basketball_YG.Wrapper
{
    public readonly struct CollisionData
    {
        public readonly CollisionType CollisionType;
        public readonly Vector3 Normal;

        public CollisionData(CollisionType collisionType, Vector3 normal)
        {
            CollisionType = collisionType;
            Normal = normal;
        }
    }
}