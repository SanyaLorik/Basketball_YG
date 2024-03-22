using Basketball_YG.Core;
using Basketball_YG.Wrapper;
using System;
using UnityEngine;

namespace Basketball_YG.Data
{
    [Serializable]
    public struct SkinPrefab
    {
        [field: SerializeField] public string Name { get; private set; }

        [field: SerializeField] public BallWrapper Ball { get; private set; }

        [field: SerializeField] public BallType Type { get; private set; }
    }
}