using YG;

namespace Basketball_YG.Sdk
{
    public class YandexBallCollection : ICollectionSkinsSender, ICollectionSkinsProvider
    {
        public void AddId(int id)
        {
            if (YandexGame.savesData.idUnlockedBallSkins.Contains(id) == true)
                return;

            YandexGame.savesData.idUnlockedBallSkins.Add(id);
            YandexGame.SaveProgress();
        }

        public bool HasId(int id)
        {
            return YandexGame.savesData.idUnlockedBallSkins.Contains(id);
        }
    }
}