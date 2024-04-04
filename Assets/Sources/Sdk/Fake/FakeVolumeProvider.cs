
namespace Basketball_YG.Sdk
{
    public class FakeVolumeProvider : IVolumeProvider
    {
        public bool IsActivedMusic { get; set; } = true;

        public bool IsActivedSound { get; set; } = true;
    }
}