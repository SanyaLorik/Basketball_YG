using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class SiteSkinSelector : SkinSelector
    {
        public SiteSkinSelector(
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinData)]
            SkinCollectionData skinCollection,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreNamingText)]
            TextSetup namingText,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreMoneyText)]
            TextSetup moneyText) : base(skinCollection, namingText, moneyText)
        {
        }
    }
}