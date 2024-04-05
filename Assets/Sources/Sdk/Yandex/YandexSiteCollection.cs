using YG;

namespace Basketball_YG.Sdk
{
    public class YandexSiteCollection : ICollectionSkinsSender, ICollectionSkinsProvider
    {
        public void AddId(int id)
        {
            if (YandexGame.savesData.idUnlockedSiteSkins.Contains(id) == true)
                return;

            YandexGame.savesData.idUnlockedSiteSkins.Add(id);
        }

        public bool HasId(int id)
        {
            return YandexGame.savesData.idUnlockedSiteSkins.Contains(id);
        }
    }
}