using UnityEngine;
using Zenject;

namespace Basketball_YG.View
{
    public class PlatformView : TransformableView
    {
        public PlatformView([InjectOptional(Optional = true, Id = "PlatformTransform")] Transform transform) : base(transform) { }

        public override void SetPosition(Vector3 position)
        {
            Transform.position = position;
        }
    }
}