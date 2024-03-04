using Basketball_YG.Config;
using Basketball_YG.Input;
using Basketball_YG.Model;
using SanyaBeer.Additional;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Core
{
    public class PlatformMovement : ITickable
    {
        private readonly ITransformableModel _model;
        private readonly IPaltformInputService _input;
        private readonly PlatformConfig _config;
        private readonly RangeValues _limits;

        public PlatformMovement(
            [InjectOptional(Optional = true, Id = GameConstants.PlatformModel)] ITransformableModel model, 
            IPaltformInputService input, 
            PlatformConfig config,
            [InjectOptional(Optional = true, Id = GameConstants.PlatfromRangeValues)] RangeValues limits)
        {
            _model = model;
            _input = input;
            _config = config;
            _limits = limits;
        }

        public void Tick()
        {
            Move();
        }

        private void Move()
        {
            Vector3 position = LerpPosition();
            if (_limits.IsInRangeForXWithoutBodrders(position) == true)
                _model.Position = position;
        }

        private Vector3 LerpPosition()
        {
            Vector3 from = _model.Position;
            Vector3 to = from;
            to.x = _input.TargetX;

            return Vector3.LerpUnclamped(from, to, _config.Speed * Time.fixedDeltaTime);
        }
    }
}