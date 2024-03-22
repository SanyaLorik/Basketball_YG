using UnityEngine;

namespace Basketball_YG.Wrapper
{
    [RequireComponent(typeof(Collider))]
    public class CollisionBody : MonoBehaviour
    {
        [field: SerializeField] public CollisionType CollisionType { get; private set; }
    } 
}