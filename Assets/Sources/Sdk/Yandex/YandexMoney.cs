using YG;

namespace Basketball_YG.Sdk
{
    public class YandexMoney : IMoneySender, IMoneyReciver
    {
        public int Money => YandexGame.savesData.money;

        public void SendMoney(int money)
        {
            YandexGame.savesData.money = money;
            YandexGame.SaveProgress();
        }
    }
}