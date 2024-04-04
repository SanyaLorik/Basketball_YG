
namespace Basketball_YG.Sdk
{
    public class FakeVolume : IVolumeProvider, IVolumeSetup
    {
        public bool IsActivedMusic { get; private set; } = false;

        public bool IsActivedSound { get; private set; } = true;

        public void SetMusic(bool actived)
        {
            IsActivedMusic = actived;
        }

        public void SetSound(bool actived)
        {
            IsActivedSound = actived;
        }
    }
}