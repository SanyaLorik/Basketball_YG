using Basketball_YG.Config;
using Basketball_YG.Sdk;
using Basketball_YG.View;
using System.Linq;
using Zenject;

namespace Basketball_YG.Model
{
    public abstract class SkinSelectingModel : IInitializable
    {
        private readonly SkinSelectingView _view;
        private readonly SkinCollectionData _collection;
        private readonly SkinPrefabStore _prefabStore;
        private readonly ICurrentSkinSender _currentSkinSender;
        private readonly ICurrentSkinProvider _currentSkinProvider;

        private int _selectedSkinId = 0;

        protected SkinSelectingModel(SkinCollectionData collection, SkinSelectingView view, SkinPrefabStore prefabStore, ICurrentSkinSender currentSkinSender, ICurrentSkinProvider currentSkinProvider)
        {
            _collection = collection;
            _view = view;
            _prefabStore = prefabStore;
            _currentSkinSender = currentSkinSender;
            _currentSkinProvider = currentSkinProvider;
        }

        public int Lenght => _collection.Skins.Length;

        public int IndexSelector { get; private set; } = 0;

        public bool HasSelectedCurrent => _collection.Skins[IndexSelector].Trade == Data.TradeType.Bought;

        public bool IsSelectedCurrent => _collection.Skins[IndexSelector].Id == _selectedSkinId;

        public void Initialize()
        {
            _prefabStore.Spawn();

            SetSkinByIndex(GetIndexById(_currentSkinProvider.Id));
            SelectCurrent();
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

        public void SelectCurrent()
        {
            _selectedSkinId = IndexSelector;
            _currentSkinSender.SetIdSkin(_selectedSkinId);
        }

        private int GetIndexById(int id)
        {
            return _collection.Skins
                .Select((value, index) => new { value, index })
                .FirstOrDefault(pair => pair.value.Id == id).index;
        }
    }
}