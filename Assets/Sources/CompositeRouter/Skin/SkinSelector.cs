using Basketball_YG.Config;
using SanyaBeer.Meta;
using System;

namespace Basketball_YG.CompositeRoot
{
    public abstract class SkinSelector
    {
        protected readonly SkinCollectionData SkinCollection;
        protected readonly TextSetup NamingText;
        protected readonly TextSetup MoneyText;

        protected SkinSelector(SkinCollectionData skinCollection, TextSetup namingText, TextSetup moneyText)
        {
            SkinCollection = skinCollection;
            NamingText = namingText;
            MoneyText = moneyText;
        }

        public void Next()
        {
            throw new NotImplementedException();
        }

        public void Back()
        {
            throw new NotImplementedException();
        }

        public void Select()
        {
            throw new NotImplementedException();
        }

        public void BuyForMoney()
        {

        }

        public void BuyForVideo()
        {

        }
    }
}