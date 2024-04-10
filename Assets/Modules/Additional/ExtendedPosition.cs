using System;
using UnityEngine;

namespace SanyaBeer.Additional
{
    [Serializable]
    public struct ExtendedPosition
    {
        [field: SerializeField] public Transform Container { get; private set; }

        [field: SerializeField] public Transform Spawnpoint { get; private set; }
    }
}