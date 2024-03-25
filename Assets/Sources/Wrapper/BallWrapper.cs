using Basketball_YG.Config;
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

            var angle = Vector3.Angle(Vector3.up, collision.contacts[0].normal);
            if (angle >= GameConstants.AngelBlock) 
                return;

            CollisionData data = new(body.Curve, body.Speed, Rigidbody.position, body.GetFinalPoint(), body.GetDirection(), body.Duration, body.Height);
            OnPerfomed?.Invoke(data);
        }
    }
}