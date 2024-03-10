using Basketball_YG.Config;
using Basketball_YG.View;
using SanyaBeer.Meta;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Model
{
    public class RewardSpeedometrModel : TransformableModel, IInformationSetupModel<string>
    {
        private readonly IRotatationView _arrowView;
        private readonly TextSetup _moneyText;

        public RewardSpeedometrModel(
            [InjectOptional(Optional = true, Id = GameConstants.SpeedometrView)]
            IRotatationView arrowView,
            [InjectOptional(Optional = true, Id = GameConstants.SpeedometrRewardmoneyText)]
            TextSetup moneyText)
        {
            _arrowView = arrowView;
            _moneyText = moneyText;
        }

        public override Vector3 Rotation
        {
            get
            {
                return base.Rotation;
            }
            set
            {
                base.Rotation = value;
                _arrowView.SetRotation(value);
            }
        }

        public void SetInformation(string information)
        {
            _moneyText.SetText(information);
        }
    }
}