using UnityEngine;

namespace Basketball_YG.Model
{
    public interface ITransformableModel
    {
        Vector3 Position { get; set; }

        Vector3 Rotation { get; set; }
    }
}