﻿using YG;

namespace Basketball_YG.Sdk
{
    public class YandexSiteSkin : ICurrentSkinProvider, ICurrentSkinSender
    {
        public int Id => YandexGame.savesData.idCurrentSiteSkin;

        public void SendIdSkin(int id)
        {
            YandexGame.savesData.idCurrentSiteSkin = id;
            YandexGame.SaveProgress();
        }
    }
}