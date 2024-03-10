using System;
using UnityEngine;


namespace Basketball_YG.Core
{
    [Serializable]
    public struct MultiplayerSlot
    {
        [field: SerializeField] public float Angel { get; private set; }

        [field: SerializeField] public int Multiplayer { get; private set; }
    }
}