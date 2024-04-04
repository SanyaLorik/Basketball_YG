using System;
using UnityEngine;

namespace Basketball_YG.Volume
{
    [Serializable]
    public struct VolumeEntity
    {
        [field: SerializeField] public VolumeType Type { get; private set; }
        [field: SerializeField] public AudioClip Clip { get; private set; }
    }
}