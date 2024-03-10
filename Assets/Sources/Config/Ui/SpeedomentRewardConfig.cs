using UnityEngine;

namespace Basketball_YG.Config
{
    [CreateAssetMenu(fileName = "SpeedomentReward", menuName = "Configs/SpeedomentReward")]
    public class SpeedomentRewardConfig : ScriptableObject
    {
        [field: SerializeField][field: Min(0)] public float Angel { get; private set; }
        [field: SerializeField][field: Min(0)] public float Duration { get; private set; }
    }
}