using Basketball_YG.Config;
using Basketball_YG.View;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Model
{
    public class PlatformModel : TransformableModel
    {
        public PlatformModel([InjectOptional(Optional = true, Id = GameConstants.PlatformView)] ITransformableView view) : base(view) { }

        public override Vector3 Position 
        {
            get
            {
                return base.Position;
            }
            set
            { 
                base.Position = value;
                View.SetPosition(value);
            } 
        }
    }
}