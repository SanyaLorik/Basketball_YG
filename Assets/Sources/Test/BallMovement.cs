using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Basketball_YG.Test
{
    public class BallMovement : MonoBehaviour
    {
        // physisc
        public Rigidbody _rigidbody;
        public float height;
        public Transform target;

        // curve
        public AnimationCurve pathCurve;
        public AnimationCurve speedCurve;
        public float durationCurve;
        public float heightCurve;

        private CancellationTokenSource _tokenSource;

        private void Start()
        {
            _tokenSource = new CancellationTokenSource();
            Path(target.position, _tokenSource.Token).Forget();
        }

        async UniTask Path(Vector3 final, CancellationToken token)
        {
            float extendedTime = 0;
            Vector3 initial = transform.position;   

            do
            {
                float ratio = extendedTime / durationCurve;
                float evaluatedPosition = pathCurve.Evaluate(ratio);
                Vector3 position = Vector3.Lerp(initial, final, ratio);
                position.y += evaluatedPosition * heightCurve;

                _rigidbody.MovePosition(position);

                float evaluatedSpeed = speedCurve.Evaluate(ratio);
                extendedTime += Time.deltaTime * evaluatedSpeed;

                await UniTask.Yield(cancellationToken: token);
            } 
            while (extendedTime < durationCurve && token.IsCancellationRequested == false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ReflactionObstalce reflactionObstalce))
            {
                _tokenSource.Cancel();
                _tokenSource = new();
                Path(reflactionObstalce.Point.position, _tokenSource.Token).Forget();
            }
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
                y = velocityY,
                x = direction.x * velocityX,
            };

            _rigidbody.velocity = velocity;
        }
    }
}