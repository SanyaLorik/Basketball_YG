using YG;

namespace Basketball_YG.Sdk
{
    public class YandexMoneySender : IMoneySender
    {
        public void SendMoney(int money)
        {
            YandexGame.savesData.money = money;
            YandexGame.SaveProgress();
        }
    }
}