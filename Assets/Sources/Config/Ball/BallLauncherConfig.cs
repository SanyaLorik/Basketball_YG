using UnityEngine;

namespace Basketball_YG.Config
{
    [CreateAssetMenu(fileName = "BallLauncher", menuName = "Configs/BallLauncher")]
    public class BallLauncherConfig : ScriptableObject
    {
        [field: SerializeField] public AnimationCurve Curve { get; private set; }

        [field: SerializeField] public AnimationCurve Speed { get; private set; }

        [field: SerializeField][Min(0)] public float Duration { get; private set; }

        [field: SerializeField][Min(0)] public float Height { get; private set; }
    }
}