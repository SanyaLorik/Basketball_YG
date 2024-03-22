using Basketball_YG.Data;
using UnityEngine;

namespace Basketball_YG.Config
{
    [CreateAssetMenu(fileName = "Ball", menuName = "Configs/PrefabBall")]
    public class PrefabBallsConfig : ScriptableObject
    {
        [field: SerializeField][field: Min(0)] public SkinPrefab[] Prefabs { get; private set; }
    }
}