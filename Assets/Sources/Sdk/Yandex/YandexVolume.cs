using YG;
using Zenject;

namespace Basketball_YG.Sdk
{
    public class YandexVolume : IInitializable, IVolumeProvider, IVolumeSetup
    {
        public bool IsActivedMusic { get; private set; }

        public bool IsActivedSound { get; private set; }

        public void Initialize()
        {
            IsActivedMusic = YandexGame.savesData.activedMusic;
            IsActivedSound = YandexGame.savesData.activedSound;
        }

        public void SetMusic(bool actived)
        {
            IsActivedMusic = actived;

            YandexGame.savesData.activedMusic = actived;
            YandexGame.SaveProgress();
        }

        public void SetSound(bool actived)
        {
            IsActivedSound = actived;

            YandexGame.savesData.activedSound = actived;
            YandexGame.SaveProgress();
        }
    }
}