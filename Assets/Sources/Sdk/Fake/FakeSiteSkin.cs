
namespace Basketball_YG.Sdk
{
    public class FakeSiteSkin : ICurrentSkinProvider, ICurrentSkinSender
    {
        public int Id { get; private set; } = 0;

        public void SendIdSkin(int id)
        {
            Id = id;
        }
    }
}