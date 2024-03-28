using Basketball_YG.Config;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class ExtralifeMenu : Menu, IInitializable, IDisposable
    {
        private readonly IMenuActivity _subendMenu;
        private readonly ClickedCallback _extralife;
        private readonly ClickedCallback _cancelExtralife;

        public ExtralifeMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiExtralifeMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiSubendMenu)]
            IMenuActivity subendMenu,
            [InjectOptional(Optional = true, Id = GameConstants.UiExtralifeButton)]
            ClickedCallback extralife,
            [InjectOptional(Optional = true, Id = GameConstants.UiCancelExtralifeButton)]
            ClickedCallback cancelExtralife) : base(signalBus, activity)
        {
            _subendMenu = subendMenu;
            _extralife = extralife;
            _cancelExtralife = cancelExtralife;
        }

        public void Initialize()
        {
            _extralife.AddListner(OnTakeExtralife);
            _cancelExtralife.AddListner(OnCancelExtralife);
        }

        public void Dispose() 
        {
            _extralife.RemoveListener(OnTakeExtralife);
            _cancelExtralife.RemoveListener(OnCancelExtralife);
        }

        private void OnTakeExtralife()
        {
            throw new NotImplementedException();
        }

        private void OnCancelExtralife()
        {
            _subendMenu.Show();
            Hide();
        }
    }
}