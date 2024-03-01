using Basketball_YG.View;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Model
{
    public class PlatformModel : TransformableModel
    {
        public PlatformModel([InjectOptional(Optional = true, Id = "PlatformView")] ITransformableView view) : base(view) { }

        public override Vector3 Position 
        { 
            get => base.Position; 
            set => View.SetPosition(value); 
        }
    }
}