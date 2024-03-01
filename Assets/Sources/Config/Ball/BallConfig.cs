using UnityEngine;

namespace Basketball_YG.Config
{
    [CreateAssetMenu(fileName = "Ball", menuName = "Configs/Ball")]
    public class BallConfig : ScriptableObject
    {
        [field: SerializeField][field: Min(0)] public float Speed { get; private set; }
    }
}