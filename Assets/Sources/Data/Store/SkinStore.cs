using System;
using UnityEngine;

namespace Basketball_YG.Data
{
    [Serializable]
    public struct SkinStore
    {
        public uint Index;
        public int Price;
        public bool IsBought;
        public GameObject Prefab;
    }
}