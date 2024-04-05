using Basketball_YG.Animation;
using Basketball_YG.Model;
using System;

namespace Basketball_YG.Core
{
    public abstract class SkinSelector
    {
        private readonly SkinSelectingModel _model;
        private readonly NotificationPopup _notificationPopup;

        protected SkinSelector(SkinSelectingModel model, NotificationPopup notificationPopup)
        {
            _model = model;
            _notificationPopup = notificationPopup;
        }

        public void Next()
        {
            Change(() => _model.IndexSelector + 1 < _model.Lenght, 1); 
        }

        public void Back()
        {
            Change(() => _model.IndexSelector - 1 >= 0, -1);
        }

        public void Select()
        {
            if (_model.HasSelectedCurrent == false)
                return;

            if (_model.IsSelectedCurrent == true)
            {
                _notificationPopup.NotifyBallAlreadySelected();
                return;
            }

            _model.SelectCurrent();
        }

        public void BuyForMoney()
        {
            if (_model.CanBuyCurrentSkin == false)
            {
                _notificationPopup.NotifyNoEnoughtMoney();
                return;
            }

            _model.BuyCurrent();
            _model.SelectCurrent();
        }

        public void BuyForVideo()
        {
            throw new NotImplementedException();
        }

        public void SelectLastOpenedSkin()
        {
            _model.SetSkinByIndex(_model.IndexSelector);
        }

        private void Change(Func<bool> predicate, int direction)
        {
            if (predicate.Invoke() == false)
                return;

            _model.SetSkinByIndex(_model.IndexSelector + direction);
        }
    }
}