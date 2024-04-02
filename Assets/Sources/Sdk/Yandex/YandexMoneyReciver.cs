using YG;

namespace Basketball_YG.Sdk
{
    public class YandexMoneyReciver : IMoneyReciver
    {
        public int Money => YandexGame.savesData.money;
    }
}