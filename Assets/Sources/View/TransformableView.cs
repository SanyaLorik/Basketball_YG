using UnityEngine;

namespace Basketball_YG.View
{
    public abstract class TransformableView : ITransformableView
    {
        protected readonly Transform Transform;

        public TransformableView(Transform transform)
        {
            Transform = transform;
        }

        public abstract void SetPosition(Vector3 position);
    }
}