namespace Basketball_YG.Sdk
{
    public class FakeMoney : IMoneySender, IMoneyReciver
    {
        public int Money { get; private set; } = 1000;

        public void SendMoney(int money)
        {
            Money = money;
        }
    }
}