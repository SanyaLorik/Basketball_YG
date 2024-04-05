
namespace Basketball_YG.Sdk
{
    public class FakeSiteSkin : ICurrentSkinProvider, ICurrentSkinSender
    {
        public int Id { get; private set; } = 0;

        public void SetIdSkin(int id)
        {
            Id = id;
        }
    }
}