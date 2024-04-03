using YG;

namespace Basketball_YG.Sdk
{
    public class YandexScoreSender : IScoreSender
    {
        public void SendScore(int score)
        {
            YandexGame.savesData.score = score;
        }
    }
}