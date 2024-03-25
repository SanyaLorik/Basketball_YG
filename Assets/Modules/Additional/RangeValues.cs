using System;
using UnityEngine;

namespace SanyaBeer.Additional
{
    [Serializable]
    public struct RangeValues
    {
        [SerializeField] private Transform _from;
        [SerializeField] private Transform _to;

        public float FromX => _from.position.x;

        public float ToX => _to.position.x;

        public bool IsInRangeForXWithoutBodrders(Vector3 position)
        {
            return _from.position.x < position.x && position.x < _to.position.x;
        }
    }
}