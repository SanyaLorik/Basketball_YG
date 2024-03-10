using UnityEngine;

namespace Basketball_YG.View
{
    public class RewardSpeedometrView : TransformableView
    {
        public RewardSpeedometrView(Transform transform) : base(transform)
        {

        }

        public override void SetRotation(Vector3 rotation)
        {
            Transform.localEulerAngles = rotation;
        }
    }
}