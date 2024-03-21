using UnityEngine;

namespace Basketball_YG.Model
{
    public abstract class PositionModel : IPositionModel
    {
        public virtual Vector3 Position { get; set; }
    }
}