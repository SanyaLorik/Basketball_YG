using Basketball_YG.View;
using SanyaBeer.Meta;
using UnityEngine;

namespace Basketball_YG.Model
{
    public class RewardSpeedometrModel : TransformableModel, IInformationSetupModel<string>
    {
        private readonly IRotatationView _arrowView;
        private readonly TextSetup _moneyText;

        public RewardSpeedometrModel(IRotatationView arrowView, TextSetup moneyText)
        {
            _arrowView = arrowView;
            _moneyText = moneyText;
        }

        // localEulerAngles
        public override Vector3 Rotation
        {
            get
            {
                return base.Rotation;
            }
            set
            {
                base.Position = value;
                _arrowView.SetRotation(value);
            }
        }

        public void SetInformation(string information)
        {
            _moneyText.SetText(information);
        }
    }
}