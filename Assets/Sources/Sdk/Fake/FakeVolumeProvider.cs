
namespace Basketball_YG.Sdk
{
    public class FakeVolumeProvider : IVolumeProvider
    {
        public bool IsActivedMusic { get; set; } = false;

        public bool IsActivedSound { get; set; } = true;
    }
}