using YG;
using Zenject;

namespace Basketball_YG.Sdk
{
    public class YandexVolumeProvider : IVolumeProvider, IInitializable
    {
        private bool _isActivedMusic;
        private bool _isActivedSound;

        public void Initialize()
        {
            IsActivedMusic = YandexGame.savesData.activedMusic;
            IsActivedSound = YandexGame.savesData.activedSound;
        }

        public bool IsActivedMusic 
        {
            get => _isActivedMusic;
            set
            {
                _isActivedMusic = value;

                YandexGame.savesData.activedMusic = value;
                YandexGame.SaveProgress();
            }
        }

        public bool IsActivedSound
        {
            get => _isActivedSound;
            set
            {
                _isActivedSound = value;

                YandexGame.savesData.activedSound = value;
                YandexGame.SaveProgress();
            }
        }
    }
}