using UnityEngine;

namespace Basketball_YG.View
{
    public abstract class PositionView : IPositionView
    {
        protected readonly Transform Transform;

        public PositionView(Transform transform)
        {
            Transform = transform;
        }

        public virtual void SetPosition(Vector3 position)
        {
            Transform.position = position;
        }
    }
}