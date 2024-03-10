using Basketball_YG.Config;
using UnityEngine;
using Zenject;

namespace Basketball_YG.View
{
    public class RewardSpeedometrView : TransformableView
    {
        public RewardSpeedometrView([InjectOptional(Optional = true, Id = GameConstants.RewardSpeedometrArrow)] Transform transform) : base(transform)
        {

        }

        public override void SetRotation(Vector3 rotation)
        {
            Transform.localEulerAngles = rotation;
        }
    }
}