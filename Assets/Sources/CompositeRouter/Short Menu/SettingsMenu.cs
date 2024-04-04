using Basketball_YG.Config;
using Basketball_YG.Sdk;
using Basketball_YG.Volume;
using SanyaBeer.Meta;
using System.Diagnostics;
using Zenject;

namespace Basketball_YG.CompositeRoot
{
    public class SettingsMenu : ShortMenu
    {
        private readonly CheckedBox _sound;
        private readonly CheckedBox _music;
        private readonly IVolumeProvider _volumeProvider;
        private readonly VolumeManagement _volumeManagement;

        public SettingsMenu(
            SignalBus signalBus,
            [InjectOptional(Optional = true, Id = GameConstants.UiSettingsMenuActivity)]
            ElementActivity activity,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonCloseSettingsMenu)]
            ClickedCallback close,
            [InjectOptional(Optional = true, Id = GameConstants.UiCheckboxSoundMenu)]
            CheckedBox sound,
            [InjectOptional(Optional = true, Id = GameConstants.UiCheckboxMusicMenu)]
            CheckedBox music,
            IVolumeProvider volumeProvider,
            VolumeManagement volumeManagement) : base(signalBus, activity, close)
        {
            _sound = sound;
            _music = music;
            _volumeProvider = volumeProvider;
            _volumeManagement = volumeManagement;
        }

        public override void Initialize()
        {
            base.Initialize();

            _sound.Initialize();
            _music.Initialize();

            _sound.AddListenerToChecking(OnSoundChecking);
            _sound.AddListenerToUnchecking(OnSoundUnchecking);
            _music.AddListenerToChecking(OnMusicChecking);
            _music.AddListenerToUnchecking(OnMusicUnchecking);

            HandleInitialVolume();
        }

        public override void Dispose()
        {
            base.Dispose();

            _sound.Dispose();
            _music.Dispose();

            _sound.RemoveListenerToChecking(OnSoundChecking);
            _sound.RemoveListenerToUnchecking(OnSoundUnchecking);
            _music.RemoveListenerToChecking(OnMusicChecking);
            _music.RemoveListenerToUnchecking(OnMusicUnchecking);
        }

        private void OnSoundChecking()
        {
            _sound.SetChecking();
            _volumeManagement.TurnOnSound();
        }

        private void OnSoundUnchecking()
        {
            _sound.SetUncheking();
            _volumeManagement.TurnOffSound();
        }

        private void OnMusicChecking()
        {
            _music.SetChecking();
            _volumeManagement.TurnOnMusic();
            _volumeManagement.PlayMusic(VolumeType.MainMusic);
        }

        private void OnMusicUnchecking()
        {
            _music.SetUncheking();
            _volumeManagement.TurnOffMusic();
        }

        private void HandleInitialVolume()
        {
            if (_volumeProvider.IsActivedSound == false)
                _sound.SetUncheking();

            if (_volumeProvider.IsActivedMusic == false)
                _music.SetUncheking();
        }
    }
}