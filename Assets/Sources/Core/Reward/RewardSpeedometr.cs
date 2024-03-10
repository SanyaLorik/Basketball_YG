using Basketball_YG.Config;
using Basketball_YG.Model;
using System.Collections;
using UnityEngine;

namespace Basketball_YG.Core
{
    public class RewardSpeedometr
    {
        private readonly IRotationModel _arrowModel;
        private readonly IInformationSetupModel<string> _moneyText;
        private readonly IMoney _money;
        private readonly SpeedomentRewardConfig _config;
        private readonly MultiplayerSlot[] _multipliers;

        private Vector3 _currentAngle;

        public RewardSpeedometr(IRotationModel arrowModel, IInformationSetupModel<string> moneyText, IMoney money, SpeedomentRewardConfig config, MultiplayerSlot[] multipliers)
        {
            _arrowModel = arrowModel;
            _moneyText = moneyText;
            _money = money;
            _config = config;
            _multipliers = multipliers;
        }

        public void StartArrow()
        {

        }

        public void StopArrow()
        {

        }

        public void ReturToInitialPosition()
        {
            _arrowModel.Rotation = Vector3.zero;
        }

        private int CalculatedMultiplier
        {
            get
            {
                float arrowAngel = _currentAngle.z + _config.Angel;

                foreach (var multiplayer in _multipliers)
                {
                    float multiplayerAngel = multiplayer.Angel + _config.Angel;
                    if (arrowAngel > multiplayerAngel)
                        return multiplayer.Multiplayer;
                }

                return _multipliers[0].Multiplayer;
            }
        }

        private IEnumerator Rotate()
        {
            Vector3 initial = new(0, 0, _config.Angel);
            Vector3 final = new(0, 0, -_config.Angel);

            while (this != null)
            {
                float expandedTime = 0;

                do
                {
                    expandedTime = Lerp(initial, final, expandedTime);
                    UpdateCounterText();
                    yield return null;
                }
                while (_config.Duration > expandedTime);

                expandedTime = 0;

                do
                {
                    expandedTime = Lerp(final, initial, expandedTime);
                    UpdateCounterText();
                    yield return null;
                }
                while (_config.Duration > expandedTime);
            }
        }

        private float Lerp(Vector3 initial, Vector3 final, float expanded)
        {
            var lerpRatio = expanded / _config.Duration;
            _currentAngle = Vector3.Lerp(initial, final, lerpRatio);
            _arrowModel.Rotation = _currentAngle;

            expanded += Time.deltaTime;

            return expanded;
        }

        private void UpdateCounterText()
        {
            int money = _money.Money * CalculatedMultiplier;
            _moneyText.SetInformation(money.ToString());
        }
    }
}