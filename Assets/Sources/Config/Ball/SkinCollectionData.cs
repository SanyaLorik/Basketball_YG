using Basketball_YG.Data;
using UnityEngine;

namespace Basketball_YG.Config
{
    [CreateAssetMenu(fileName = "Skin", menuName = "Configs/Skin")]
    public class SkinCollectionData : ScriptableObject
    {
        [field: SerializeField] public SkinStore[] Skins { get; private set; }

        public int Lenght => Skins.Length;
    }
}