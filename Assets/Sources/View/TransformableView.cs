using UnityEngine;

namespace Basketball_YG.View
{
    public abstract class TransformableView : PositionView, ITransformableView
    {
        protected TransformableView(Transform transform) : base(transform)
        {

        }

        public abstract void SetRotation(Vector3 rotation);
    }
}