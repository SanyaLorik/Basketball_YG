using UnityEngine;

namespace Basketball_YG.Config
{
    [CreateAssetMenu(fileName = "Platfrom", menuName = "Configs/Platfrom")]
    public class PlatformConfig : ScriptableObject
    {
        [field: SerializeField][field: Min(0)] public float Speed {  get; private set; }
    }
}