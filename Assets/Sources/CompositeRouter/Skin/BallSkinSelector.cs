using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class BallSkinSelector : SkinSelector
    {
        public BallSkinSelector(
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinData)]
            SkinCollectionData skinCollection,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreNamingText)]
            TextSetup namingText,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreMoneyText)]
            TextSetup moneyText) : base(skinCollection, namingText, moneyText)
        {
        }
    }
}