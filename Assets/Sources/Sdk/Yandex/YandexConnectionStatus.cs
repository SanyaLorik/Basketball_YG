namespace Basketball_YG.Sdk
{
    public class YandexConnectionStatus : IContectionStatus
    {
        public bool IsConnected => YG.YandexGame.SDKEnabled;
    }
}