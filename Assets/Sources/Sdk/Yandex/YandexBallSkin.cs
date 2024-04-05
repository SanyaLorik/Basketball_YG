﻿using YG;

namespace Basketball_YG.Sdk
{
    public class YandexBallSkin : ICurrentSkinProvider, ICurrentSkinSender
    {
        public int Id => YandexGame.savesData.idCurrentBallSkin;

        public void SetIdSkin(int id)
        {
            YandexGame.savesData.idCurrentBallSkin = id;
            YandexGame.SaveProgress();
        }
    }
}