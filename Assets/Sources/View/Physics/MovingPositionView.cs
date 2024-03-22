using UnityEngine;

namespace Basketball_YG.View
{
    public class MovingPositionView
    {
        private readonly Rigidbody _rigidbody;

        public MovingPositionView(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void SetPosition(Vector3 position)
        {
            _rigidbody.position = position;
        }
    }
}