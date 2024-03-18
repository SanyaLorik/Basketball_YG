using System;
using UnityEngine;

namespace Basketball_YG.Data
{
    [Serializable]
    public struct SkinStore
    {
        //public uint Index;
        public string Name;
        public int Price;
        public TradeType Trade;
        public GameObject Prefab;
    }
}