using Basketball_YG.Core;
using UnityEngine;

namespace Basketball_YG.Wrapper
{
    [RequireComponent(typeof(Collider))]
    public class CollisionBody : MonoBehaviour
    {
        [field: SerializeField] public AnimationCurve Curve { get; private set; }

        [field: SerializeField] public AnimationCurve Speed { get; private set; }

        [field: SerializeField][Min(0)] public float Duration { get; private set; }

        [field: SerializeField][Min(0)] public float Height { get; private set; }

        [field: SerializeField][Min(0)] public DirectionBoundType Direction { get; private set; }

        [field: SerializeField][Min(0)] public Transform FinalPoint { get; private set; }

        [SerializeField] private bool _canChangedDirection;
        [SerializeField] private bool _hasFinalPoint;

        public DirectionBoundType GetDirection()
        {
            if (_canChangedDirection == true)
                return Direction;

            return DirectionBoundType.NoChanching;
        }

        public Vector3? GetFinalPoint()
        {
            if (_hasFinalPoint == true)
                return FinalPoint.position;

            return default;
        }
    }
}