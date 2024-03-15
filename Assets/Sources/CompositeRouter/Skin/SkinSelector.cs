using Basketball_YG.Config;
using SanyaBeer.Meta;
using System;

namespace Basketball_YG.CompositeRoot
{
    public abstract class SkinSelector
    {
        protected readonly SkinCollectionData _skinCollection;
        protected readonly TextSetup NamingText;
        protected readonly TextSetup MoneyText;

        private int _indexSelector = 0;

        protected SkinSelector(SkinCollectionData skinCollection, TextSetup namingText, TextSetup moneyText)
        {
            _skinCollection = skinCollection;
            NamingText = namingText;
            MoneyText = moneyText;
        }

        public void Next()
        {
            Change(() => _indexSelector + 1 < _skinCollection.Lenght, 1); 
        }

        public void Back()
        {
            Change(() => _indexSelector - 1 > 0, -1);
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

        private void Change(Func<bool> predicate, int direction)
        {
            if (predicate.Invoke() == false)
                return;
            
            _indexSelector += direction;
        }
    }
}