using System;
using UnityEngine;

namespace Basketball_YG.Wrapper
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class BallWrapper : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody {  get; private set; }

        public Action<CollisionData> OnCollision;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out CollisionBody body) == true)
                OnCollision?.Invoke(new CollisionData(body.CollisionType, collision.contacts[0].normal));
        }
    }
}