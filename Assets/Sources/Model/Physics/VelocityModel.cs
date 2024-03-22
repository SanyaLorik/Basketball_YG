using Basketball_YG.View;
using UnityEngine;

namespace Basketball_YG.Model
{
    public class VelocityModel
    {
        private readonly VelocityView _view;

        public VelocityModel(VelocityView view)
        {
            _view = view;
        }

        public void SetVelocity(Vector3 velocity) 
        {
            _view.Velocity = velocity;
        }
    }
}