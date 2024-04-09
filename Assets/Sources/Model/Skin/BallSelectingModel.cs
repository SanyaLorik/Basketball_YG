using Basketball_YG.Config;
using Basketball_YG.Sdk;
using Basketball_YG.View;
using Zenject;

namespace Basketball_YG.Model
{
    public class BallSelectingModel : SkinSelectingModel
    {
        public BallSelectingModel(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinData)]
            SkinCollectionData collection,
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinSelectingView)]
            SkinSelectingView view,
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinPrefabStore)]
            SkinPrefabStore prefabStore,
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinStoreSdkSender)]
            ICurrentSkinSender currentSkinSender,
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinStoreSdkProvider)]
            ICurrentSkinProvider currentSkinProvider, 
            IMoneyReciver moneyReciver, 
            IMoneySender moneySender,
            [InjectOptional(Optional = true, Id = GameConstants.BallCollectionSdkSkinsProvider)]
            ICollectionSkinsProvider skinProvider,
            [InjectOptional(Optional = true, Id = GameConstants.BallCollectionSdkSkinsSender)]
            ICollectionSkinsSender skinSender) :
            base(signalBus, collection, view, prefabStore, currentSkinSender, currentSkinProvider, moneyReciver, moneySender, skinProvider, skinSender)
        {

        }

        public override void Initialize()
        {
            base.Initialize();

            PrefabStore.Spawn();
        }
    }
}