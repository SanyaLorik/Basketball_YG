
namespace Basketball_YG.Sdk
{
    public class FakeScoreReciver : IScoreReciver
    {
        public int Score => int.MaxValue;
    }
}