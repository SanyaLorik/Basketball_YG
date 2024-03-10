using Basketball_YG.Config;
using Basketball_YG.View;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Model
{
    public class PlatformModel : PositionModel
    {
        private readonly IPositionView _view;

        public PlatformModel([InjectOptional(Optional = true, Id = GameConstants.PlatformView)] IPositionView view)
        {
            _view = view;
        }

        public override Vector3 Position 
        {
            get
            {
                return base.Position;
            }
            set
            { 
                base.Position = value;
                _view.SetPosition(value);
            } 
        }
    }
}