using Basketball_YG.Config;
using Basketball_YG.Data;
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
        protected readonly SkinPrefabStore PrefabStore;

        private readonly SignalBus _signalBus;
        private readonly SkinSelectingView _view;
        private readonly SkinCollectionData _collection;
        private readonly ICurrentSkinSender _currentSkinSender;
        private readonly ICurrentSkinProvider _currentSkinProvider;
        private readonly IMoneyReciver _moneyReciver;
        private readonly IMoneySender _moneySender;
        private readonly ICollectionSkinsProvider _skinsProvider;
        private readonly ICollectionSkinsSender _skinsSender;

        private int _selectedSkinId = 0;

        protected SkinSelectingModel(SignalBus signalBus, SkinCollectionData collection, SkinSelectingView view, SkinPrefabStore prefabStore, ICurrentSkinSender currentSkinSender, ICurrentSkinProvider currentSkinProvider, IMoneyReciver moneyReciver, IMoneySender moneySender, ICollectionSkinsProvider skinsProvider, ICollectionSkinsSender skinsSender)
        {
            _signalBus = signalBus;
            _collection = collection;
            _view = view;
            PrefabStore = prefabStore;
            _currentSkinSender = currentSkinSender;
            _currentSkinProvider = currentSkinProvider;
            _moneyReciver = moneyReciver;
            _moneySender = moneySender;
            _skinsProvider = skinsProvider;
            _skinsSender = skinsSender;
        }

        public int Lenght => _collection.Skins.Length;

        public int IndexSelector { get; private set; } = 0;

        public bool HasSelectedCurrent => CurrentSkin.Trade == TradeType.Bought || _skinsProvider.HasId(CurrentSkin.Id) == true;

        public bool IsSelectedCurrent => CurrentSkin.Id == _selectedSkinId;

        public bool CanBuyCurrentSkin => CurrentSkin.Price <= _moneyReciver.Money;

        public void Initialize()
        {
            PrefabStore.Spawn();
            _signalBus.Subscribe<BoostrapLoadedSignal>(OnLoad);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<BoostrapLoadedSignal>(OnLoad);
        }

        public void SetSkinByIndex(int index)
        {
            IndexSelector = index;
            PrefabStore.ShowOnlyCurrentSkin(index);

            var skin = _collection.Skins[index];

            if (_skinsProvider.HasId(skin.Id) == true)
            {
                _view.ShowOnlyButtonByType(TradeType.Bought);
                _view.HidePrice();
            }
            else
            {
                _view.ShowOnlyButtonByType(skin.Trade);
                _view.SetPrice(skin.Price.ToString());
            }

            _view.SetName(skin.Name);
        }

        public void SelectCurrent()
        {
            _selectedSkinId = CurrentSkin.Id;
            _currentSkinSender.SendIdSkin(_selectedSkinId);

            OnSelectedOnId(_currentSkinProvider.Id);
        }

        public void BuyCurrent()
        {
            int money = _moneyReciver.Money - CurrentSkin.Price;
            _moneySender.SendMoney(money);
            _skinsSender.AddId(CurrentSkin.Id);

            SetSkinByIndex(GetIndexById(CurrentSkin.Id));

            _signalBus.Fire(new TotalMoneySignal(money));
        }

        private SkinStore CurrentSkin => _collection.Skins[IndexSelector];

        private void OnLoad()
        {
            _selectedSkinId = _currentSkinProvider.Id;
            IndexSelector = GetIndexById(_currentSkinProvider.Id);

            SetSkinByIndex(IndexSelector);
            OnSelectedOnId(_currentSkinProvider.Id);
        }

        private int GetIndexById(int id)
        {
            return _collection.Skins
                .Select((value, index) => new { value, index })
                .FirstOrDefault(pair => pair.value.Id == id).index;
        }

        protected virtual void OnSelectedOnId(int id)
        {

        }
    }
}