using Basketball_YG.Config;
using System;
using UnityEngine;

namespace Basketball_YG.Wrapper
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class BallWrapper : MonoBehaviour
    {
        private bool _isDetecting = true;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        public Rigidbody Rigidbody {  get; private set; }

        public event Action<CollisionData> OnCollision;
        public event Action OnScored;

        private void OnCollisionEnter(Collision collision)
        {
            if (_isDetecting == false)
                return;

            if (collision.gameObject.TryGetComponent(out CollisionBody body) == false) 
                return;

            var angle = Vector3.Angle(Vector3.up, collision.contacts[0].normal);
            if (angle >= GameConstants.AngelBlock) 
                return;

            CollisionData data = new(body.Curve, body.Speed, Rigidbody.position, body.GetFinalPoint(), body.GetDirection(), body.Duration, body.Height);
            OnCollision?.Invoke(data);
        }

        public void Score()
        {
            _isDetecting = false;
            OnScored?.Invoke();
            Debug.Log("Ball is off");
        }
    }
}