using UnityEngine;

namespace Basketball_YG.Model
{
    public abstract class TransformableModel : PositionModel, IRotationModel
    {
        public virtual Vector3 Rotation { get; set; }
    }
}