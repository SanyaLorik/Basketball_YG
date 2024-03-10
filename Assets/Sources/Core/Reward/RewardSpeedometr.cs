using Basketball_YG.Config;
using Basketball_YG.Model;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Core
{
    public class RewardSpeedometr : IDisposable, IInitializable
    {
        private readonly IRotationModel _arrowModel;
        private readonly IInformationSetupModel<string> _moneyText;
        private readonly IMoney _matchMoney;
        private readonly MultiplayerSlot[] _multipliers;
        private readonly RewardSpeedometrConfig _config;

        private CancellationTokenSource _cancellationToken;
        private Vector3 _currentAngle;

        public RewardSpeedometr(
            [InjectOptional(Optional = true, Id = GameConstants.SpeedometrRotationModel)]
            IRotationModel arrowModel,
            [InjectOptional(Optional = true, Id = GameConstants.SpeedometrInformationModel)]
            IInformationSetupModel<string> moneyText,
            [InjectOptional(Optional = true, Id = GameConstants.MoneyMatch)]
            IMoney matchMoney,
            [InjectOptional(Optional = true, Id = GameConstants.SpeedometrMultiplayerSlot)]
            MultiplayerSlot[] multipliers,
            RewardSpeedometrConfig config)
        {
            _arrowModel = arrowModel;
            _moneyText = moneyText;
            _matchMoney = matchMoney;
            _multipliers = multipliers;
            _config = config;
        }

        public void Dispose()
        {
            _cancellationToken?.Cancel();
            _cancellationToken?.Dispose();
        }

        public void StartArrow()
        {
            _cancellationToken = new();
            Rotate(_cancellationToken.Token).Forget();
        }

        public void StopArrow()
        {
            _cancellationToken.Cancel();
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

        private async UniTaskVoid Rotate(CancellationToken token)
        {
            Vector3 initial = new(0, 0, _config.Angel);
            Vector3 final = new(0, 0, -_config.Angel);

            while (token.IsCancellationRequested == false)
            {
                float expandedTime = 0;
                (initial, final) = (final, initial);

                do
                {
                    expandedTime = Lerp(initial, final, expandedTime);
                    UpdateCounterText();

                    await UniTask.Yield(cancellationToken: token);
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
            int money = _matchMoney.Money * CalculatedMultiplier;
            _moneyText.SetInformation(money.ToString());
        }

        public void Initialize()
        {
            StartArrow();
        }
    }
}