using UnityEngine;

namespace Basketball_YG.View
{
    public abstract class TransformableView : PositionView, IRotatationView
    {
        protected TransformableView(Transform transform) : base(transform)
        {

        }

        public abstract void SetRotation(Vector3 rotation);
    }
}