using YG;

namespace Basketball_YG.Sdk
{
    public class YandexMoneySender : IMoneySender
    {
        public void Send(int money)
        {
            YandexGame.savesData.money = money; ;
        }
    }
}