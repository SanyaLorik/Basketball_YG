﻿using UnityEngine;

namespace Basketball_YG.View
{
    public class VelocityView
    {
        private readonly Rigidbody _rigidbody;

        public VelocityView(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public Vector3 Velocity
        {
            get => _rigidbody.velocity;
            set => _rigidbody.velocity = value;
        }
    }
}