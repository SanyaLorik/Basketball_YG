using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using Basketball_YG.Sdk;
using Basketball_YG.View;
using System;
using System.Linq;
using Zenject;

namespace Basketball_YG.Model
{
    public abstract class SkinSelectingModel : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly SkinSelectingView _view;
        private readonly SkinCollectionData _collection;
        private readonly SkinPrefabStore _prefabStore;
        private readonly ICurrentSkinSender _currentSkinSender;
        private readonly ICurrentSkinProvider _currentSkinProvider;

        private int _selectedSkinId = 0;

        protected SkinSelectingModel(SignalBus signalBus, SkinCollectionData collection, SkinSelectingView view, SkinPrefabStore prefabStore, ICurrentSkinSender currentSkinSender, ICurrentSkinProvider currentSkinProvider)
        {
            _signalBus = signalBus;
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

            _signalBus.Subscribe<BoostrapLoadedSignal>(OnLoad);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<BoostrapLoadedSignal>(OnLoad);
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
            _selectedSkinId = _collection.Skins[IndexSelector].Id;
            _currentSkinSender.SetIdSkin(_selectedSkinId);
        }

        private void OnLoad()
        {
            _selectedSkinId = _currentSkinProvider.Id;
            IndexSelector = GetIndexById(_currentSkinProvider.Id);

            SetSkinByIndex(IndexSelector);
        }

        private int GetIndexById(int id)
        {
            return _collection.Skins
                .Select((value, index) => new { value, index })
                .FirstOrDefault(pair => pair.value.Id == id).index;
        }
    }
}