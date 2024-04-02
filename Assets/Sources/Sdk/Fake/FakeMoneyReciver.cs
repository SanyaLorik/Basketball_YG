
namespace Basketball_YG.Sdk
{
    public class FakeMoneyReciver : IMoneyReciver
    {
        public int Money => int.MaxValue;
    }
}