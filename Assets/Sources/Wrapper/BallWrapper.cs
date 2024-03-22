using SanyaBeer.Event;
using System;
using UnityEngine;

namespace Basketball_YG.Wrapper
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class BallWrapper : MonoBehaviour, IEventObserver<CollisionData>
    {
        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        public Rigidbody Rigidbody {  get; private set; }

        public event Action<CollisionData> OnPerfomed;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out CollisionBody body) == true)
                OnPerfomed?.Invoke(new CollisionData(body.Height, collision.contacts[0].point));
        }
    }
}