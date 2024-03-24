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
            if (collision.gameObject.TryGetComponent(out CollisionBody body) == false) 
                return;

            CollisionData data = new(body.Curve, body.Speed, collision.contacts[0].point, body.GetFinalPoint(), body.GetDirection(), body.Duration, body.Height);
            OnPerfomed?.Invoke(data);
        }
    }
}