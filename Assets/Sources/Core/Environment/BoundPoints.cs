using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Core
{
    [Serializable]
    public class BoundPoints : IInitializable
    {
        [SerializeField] private Transform[] _points;

        public Vector3[] Points { get; private set; }

        public void Initialize()
        {
            Points = _points.Select(i => i.position).ToArray();
        }
    }
}