using Basketball_YG.Model.Signal;
using YG;
using Zenject;

namespace Basketball_YG.Sdk
{
    public class YandexScoreSender : IScoreSender
    {
        private readonly SignalBus _signalBus;

        public YandexScoreSender(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void SendScore(int score)
        {
            if (score <= YandexGame.savesData.score)
                return;

            YandexGame.savesData.score = score;
            _signalBus.Fire(new TotalScoreSignal(score));

            YandexGame.SaveProgress();
        }
    }
}