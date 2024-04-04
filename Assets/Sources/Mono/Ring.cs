using Basketball_YG.Wrapper;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Basketball_YG.Mono
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Ring : MonoBehaviour
    {
        private readonly HashSet<BallWrapper> _balls = new();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BallWrapper ball) == false)
                return;

            if (_balls.Contains(ball) == true)
                return;

            if (IsAbove(ball.transform.position) == false)
                return;

            _balls.Add(ball);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out BallWrapper ball) == false)
                return;

            if (_balls.Contains(ball) == false)
                return;

            _balls.Remove(ball);

            if (IsUnder(ball.transform.position) == false)
                return;

            ball.Score();
        }

        private bool IsAbove(Vector3 ball)
        {
            return transform.position.y < ball.y;
        }

        private bool IsUnder(Vector3 ball)
        {
            return transform.position.y > ball.y;
        }
    }
}