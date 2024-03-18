using Basketball_YG.Config;
using Basketball_YG.View;
using Zenject;

namespace Basketball_YG.Model
{
    public class BallSelectingModel : SkinSelectingModel
    {
        public BallSelectingModel(
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinData)]
            SkinCollectionData collection,
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinSelectingView)]
            SkinSelectingView view,
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinPrefabStore)]
            SkinPrefabStore prefabStore) : base(collection, view, prefabStore)
        {

        }
    }
}