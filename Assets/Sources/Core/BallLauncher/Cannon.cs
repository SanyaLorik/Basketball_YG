using System;
using UnityEngine;

namespace Basketball_YG.Core
{
    [Serializable]
    public struct Cannon
    {
        [field: SerializeField] public DirectionBoundType Direction { get; private set; }

        [SerializeField] private Transform _launchPoint;

        public readonly Vector3 LaunchPoint => _launchPoint.position;
    }
}