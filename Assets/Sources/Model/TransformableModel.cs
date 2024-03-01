using Basketball_YG.View;
using UnityEngine;

namespace Basketball_YG.Model
{
    public abstract class TransformableModel : ITransformableModel
    {
        protected readonly ITransformableView View;

        public TransformableModel(ITransformableView view)
        {
            View = view;
        }

        public virtual Vector3 Position { get; set; }

        public virtual Vector3 Rotation { get; set; }
    }
}