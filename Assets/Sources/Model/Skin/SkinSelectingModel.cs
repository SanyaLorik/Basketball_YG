using Basketball_YG.Config;
using Basketball_YG.View;
using Zenject;

namespace Basketball_YG.Model
{
    public abstract class SkinSelectingModel : IInitializable
    {
        private readonly SkinSelectingView _view;
        private readonly SkinCollectionData _collection;
        private readonly SkinPrefabStore _prefabStore;

        protected SkinSelectingModel(SkinCollectionData collection, SkinSelectingView view, SkinPrefabStore prefabStore)
        {
            _collection = collection;
            _view = view;
            _prefabStore = prefabStore;
        }

        public int Lenght => _collection.Skins.Length;

        public int IndexSelector { get; private set; } = 0;

        public void Initialize()
        {
            _prefabStore.Spawn();
        }

        public void SetSkinByIndex(int index)
        {
            IndexSelector = index;
            _prefabStore.ShowOnlyCurrentSkin(index);

            var skin = _collection.Skins[index];
            _view.ShowOnlyButtonByType(skin.Trade);
            _view.SetName(skin.Name);
            _view.SetPrice(skin.Price.ToString());
        }
    }
}