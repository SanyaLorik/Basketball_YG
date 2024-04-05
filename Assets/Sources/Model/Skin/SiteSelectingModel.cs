using Basketball_YG.Config;
using Basketball_YG.Sdk;
using Basketball_YG.View;
using Zenject;

namespace Basketball_YG.Model
{
    public class SiteSelectingModel : SkinSelectingModel
    {
        public SiteSelectingModel(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinData)]
            SkinCollectionData collection,
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinSelectingView)]
            SkinSelectingView view, 
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinPrefabStore)]
            SkinPrefabStore prefabStore,
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinStoreSdkSender)]
            ICurrentSkinSender currentSkinSender,
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinStoreSdkProvider)]
            ICurrentSkinProvider currentSkinProvider,
            IMoneyReciver moneyReciver,
            IMoneySender moneySender,
            [InjectOptional(Optional = true, Id = GameConstants.SiteCollectionSdkSkinsProvider)]
            ICollectionSkinsProvider skinProvider,
            [InjectOptional(Optional = true, Id = GameConstants.SiteCollectionSdkSkinsSender)]
            ICollectionSkinsSender skinSender) :
            base(signalBus, collection, view, prefabStore, currentSkinSender, currentSkinProvider, moneyReciver, moneySender, skinProvider, skinSender)
        {

        }
    }
}