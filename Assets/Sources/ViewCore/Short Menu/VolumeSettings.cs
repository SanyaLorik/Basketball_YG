using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using System;
using UnityEngine;
using Zenject;

namespace Basketball_YG.ViewCore
{
    public class VolumeSettings : IInitializable, IDisposable
    {
        private IUiMenuActivity _uiMenuActivity;
        private readonly SignalBus _signalBus;

        public VolumeSettings(
            [InjectOptional(Optional = true, Id = GameConstants.UiSettingsMenu)]
            IUiMenuActivity uiMenuActivity,
            SignalBus signalBus)
        {
            _uiMenuActivity = uiMenuActivity;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ActivitySettingsSignal>(OnOpenMenu);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ActivitySettingsSignal>(OnOpenMenu);
        }

        private void OnOpenMenu(ActivitySettingsSignal activity)
        {
            if (activity.IsOpening == true)
                _uiMenuActivity.Show();
            else
                _uiMenuActivity.Hide();
        }
    }
}