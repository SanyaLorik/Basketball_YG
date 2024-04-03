using YG;

namespace Basketball_YG.Sdk
{
    public class YandexScoreReciver : IScoreReciver
    {
        public int Score => YandexGame.savesData.score;
    }
}