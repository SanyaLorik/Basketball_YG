using UnityEngine;

namespace Basketball_YG.Test
{
    public class BallMovement : MonoBehaviour
    {
        public Rigidbody _rigidbody;
        public float height;
        public Transform target;

        private void Start()
        {
            Jump();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Jump();
        }

        private void Jump()
        {
            float g = 9.8f;
            float distance = Vector3.Distance(transform.position, target.position);
            float hypotenuse = Mathf.Sqrt(height * height + distance * distance);
            float angle = Mathf.Abs(Mathf.Cos(distance / hypotenuse));

            Vector3 fromTo = target.position - transform.position;
            Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

            float x = fromToXZ.magnitude;

            float angleRadians = angle * Mathf.PI / 180;

            float v2 = (g * x * x) / (2 * (height - Mathf.Tan(angleRadians) * x) * Mathf.Pow(Mathf.Cos(angleRadians), 2));
            float v = Mathf.Sqrt(Mathf.Abs(v2));

            float velocityX = v / 2;
            float velocityY = Mathf.Sqrt(2 * height * 9.8f);

            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            Vector3 velocity = new()
            {
                y = direction.x * velocityY,
                x = direction.x * velocityX,
            };

            _rigidbody.velocity = velocity;
        }
    }
}