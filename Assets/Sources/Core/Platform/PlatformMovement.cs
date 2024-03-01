using Basketball_YG.Additional;
using Basketball_YG.Config;
using Basketball_YG.Input;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Core
{
    public class PlatformMovement : ITickable
    {
        private readonly Transform _platfrom;
        private readonly IPaltformInputService _input;
        private readonly PlatformConfig _config;
        private readonly RangeValues _limits;

        public PlatformMovement(
            [InjectOptional(Optional = true, Id = "PlatfromTransform")] Transform platfrom, 
            IPaltformInputService input, 
            PlatformConfig config,
            [InjectOptional(Optional = true, Id = "PlatfromRangeValues")] RangeValues limits)
        {
            _platfrom = platfrom;
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
                _platfrom.position = position;
        }

        private Vector3 LerpPosition()
        {
            Vector3 from = _platfrom.position;
            Vector3 to = from;
            to.x = _input.TargetX;

            return Vector3.LerpUnclamped(from, to, _config.Speed * Time.fixedDeltaTime);
        }
    }
}