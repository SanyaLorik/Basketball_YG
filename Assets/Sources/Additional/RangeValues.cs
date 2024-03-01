using System;
using UnityEngine;

namespace Basketball_YG.Additional
{
    [Serializable]
    public struct RangeValues
    {
        [SerializeField] private Transform _from;
        [SerializeField] private Transform _to;

        public bool IsInRangeForXWithoutBodrders(Vector3 position)
        {
            return _from.position.x < position.x && position.x < _to.position.x;
        }
    }
}