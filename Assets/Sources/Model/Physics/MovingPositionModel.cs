using Basketball_YG.View;
using UnityEngine;

namespace Basketball_YG.Model
{
    public class MovingPositionModel
    {
        private readonly MovingPositionView _view;

        public MovingPositionModel(MovingPositionView view)
        {
            _view = view;
        }

        public Vector3 Position { get; private set; } = Vector3.zero;

        public void SetPosition(Vector3 position)
        {
            Position = position;
            _view.SetPosition(position);
        }
    }
}