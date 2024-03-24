using Basketball_YG.Core;
using Basketball_YG.View;
using UnityEngine;

namespace Basketball_YG.Model
{
    public class MovingPositionModel
    {
        private readonly MovingPositionView _view;
        private Vector3 _last;

        public MovingPositionModel(MovingPositionView view)
        {
            _view = view;
        }

        public Vector3 Position { get; private set; } = Vector3.zero;

        public DirectionBoundType Direction {  get; set; }

        public void SetPosition(Vector3 position)
        {
            _last = Position;
            Position = position;
            _view.SetPosition(position);
        }
    }
}