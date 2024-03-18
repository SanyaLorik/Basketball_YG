using Basketball_YG.Model;
using System;

namespace Basketball_YG.Core
{
    public abstract class SkinSelector
    {
        private readonly SkinSelectingModel _model;

        protected SkinSelector(SkinSelectingModel model)
        {
            _model = model;
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
            throw new NotImplementedException();
        }

        public void BuyForMoney()
        {
            throw new NotImplementedException();
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