using Basketball_YG.Config;
using Basketball_YG.View;
using Zenject;

namespace Basketball_YG.Model
{
    public class SiteSelectingModel : SkinSelectingModel
    {
        public SiteSelectingModel(
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinData)]
            SkinCollectionData collection,
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinSelectingView)]
            SkinSelectingView view, 
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinPrefabStore)]
            SkinPrefabStore prefabStore) : base(collection, view, prefabStore)
        {

        }
    }
}