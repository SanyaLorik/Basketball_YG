using Basketball_YG.Config;
using Basketball_YG.Sdk;
using System;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    public class SdkInstaller : MonoInstaller
    {
        [SerializeField] private bool _hasSdk;

        public override void InstallBindings()
        {
            if (_hasSdk == true)
            {
                BindRealConnetion();
                BindRealMoney();
                BindRealScoreReciver();
                BindRealScoreSender();
                BindRealVolume();
                BindRealBallSkinStore();
                BindRealSiteSkinStore();
                BindRealBallCollectionSkins();
                BindRealSiteCollectionSkins();
            }
            else
            {
                BindFakeConnection();
                BindFakeMoney();
                BindFakeScoreReciver();
                BindFakeScoreSender();
                BindFakeVolume();
                BindFakeBallSkinStore();
                BindFakeSiteSkinStore();
                BindFakeBallCollectionSkins();
                BindFakeSiteCollectionSkins();
            }
        }

        private void BindFakeConnection()
        {
            Container
                .BindInterfacesAndSelfTo<FakeConnectionStatus>()
                .AsCached();
        }

        private void BindFakeMoney()
        {
            Container
                .BindInterfacesAndSelfTo<FakeMoney>()
                .AsCached();
        }

        private void BindFakeScoreReciver()
        {
            Container
                .BindInterfacesAndSelfTo<FakeScoreReciver>()
                .AsCached();
        }

        private void BindFakeScoreSender()
        {
            Container
                .BindInterfacesAndSelfTo<FakeScoreSender>()
                .AsCached();
        }

        private void BindFakeVolume()
        {
            Container
                .BindInterfacesAndSelfTo<FakeVolume>()
                .AsCached();
        }

        private void BindFakeBallSkinStore()
        {
            Container
                .Bind<FakeBallSkin>()
                .AsCached();

            Container
                .Bind<ICurrentSkinProvider>()
                .WithId(GameConstants.BallSkinStoreSdkProvider)
                .To<FakeBallSkin>()
                .FromResolve();

            Container
                .Bind<ICurrentSkinSender>()
                .WithId(GameConstants.BallSkinStoreSdkSender)
                .To<FakeBallSkin>()
                .FromResolve();
        }

        private void BindFakeSiteSkinStore()
        {
            Container
                .Bind<FakeSiteSkin>()
                .AsCached();

            Container
               .Bind<ICurrentSkinProvider>()
               .WithId(GameConstants.SiteSkinStoreSdkProvider)
               .To<FakeSiteSkin>()
               .FromResolve();

            Container
                .Bind<ICurrentSkinSender>()
                .WithId(GameConstants.SiteSkinStoreSdkSender)
                .To<FakeSiteSkin>()
                .FromResolve();
        }

        private void BindFakeBallCollectionSkins()
        {
            Container
                .Bind<FakeBallCollection>()
                .AsCached();

            Container
               .Bind<ICollectionSkinsSender>()
               .WithId(GameConstants.BallCollectionSdkSkinsSender)
               .To<FakeBallCollection>()
               .FromResolve();

            Container
                .Bind<ICollectionSkinsProvider>()
                .WithId(GameConstants.BallCollectionSdkSkinsProvider)
                .To<FakeBallCollection>()
                .FromResolve();
        }

        private void BindFakeSiteCollectionSkins()
        {
            Container
                .Bind<FakeSiteCollection>()
                .AsCached();

            Container
               .Bind<ICollectionSkinsSender>()
               .WithId(GameConstants.SiteCollectionSdkSkinsSender)
               .To<FakeSiteCollection>()
               .FromResolve();

            Container
                .Bind<ICollectionSkinsProvider>()
                .WithId(GameConstants.SiteCollectionSdkSkinsProvider)
                .To<FakeSiteCollection>()
                .FromResolve();
        }

        // Reals

        private void BindRealConnetion()
        {
            Container
                .BindInterfacesAndSelfTo<YandexConnectionStatus>()
                .AsCached();
        }

        private void BindRealMoney()
        {
            Container
                .BindInterfacesAndSelfTo<YandexMoney>()
                .AsCached();
        }

        private void BindRealScoreReciver()
        {
            Container
                .BindInterfacesAndSelfTo<YandexScoreReciver>()
                .AsCached();
        }

        private void BindRealScoreSender()
        {
            Container
                .BindInterfacesAndSelfTo<YandexScoreSender>()
                .AsCached();
        }

        private void BindRealVolume()
        {
            Container
                .BindInterfacesAndSelfTo<YandexVolume>()
                .AsCached();
        }

        private void BindRealBallSkinStore()
        {
            Container
                .Bind<ICurrentSkinProvider>()
                .WithId(GameConstants.BallSkinStoreSdkProvider)
                .To<YandexBallSkin>()
                .AsCached();

            Container
                .Bind<ICurrentSkinSender>()
                .WithId(GameConstants.BallSkinStoreSdkSender)
                .To<YandexBallSkin>()
                .AsCached();

            Container
                .BindInterfacesTo<YandexBallSkin>()
                .AsCached();
        }

        private void BindRealSiteSkinStore()
        {
            Container
                .Bind<ICurrentSkinProvider>()
                .WithId(GameConstants.SiteSkinStoreSdkProvider)
                .To<YandexSiteSkin>()
                .AsCached();

            Container
                .Bind<ICurrentSkinSender>()
                .WithId(GameConstants.SiteSkinStoreSdkSender)
                .To<YandexSiteSkin>()
                .AsCached();

            Container
                .BindInterfacesTo<YandexSiteSkin>()
                .AsCached();
        }

        private void BindRealBallCollectionSkins()
        {
            Container
                .Bind<YandexBallCollection>()
                .AsCached();

            Container
               .Bind<ICollectionSkinsSender>()
               .WithId(GameConstants.BallCollectionSdkSkinsSender)
               .To<YandexBallCollection>()
               .FromResolve();

            Container
                .Bind<ICollectionSkinsProvider>()
                .WithId(GameConstants.BallCollectionSdkSkinsProvider)
                .To<YandexBallCollection>()
                .FromResolve();
        }

        private void BindRealSiteCollectionSkins()
        {
            Container
                .Bind<YandexSiteCollection>()
                .AsCached();

            Container
               .Bind<ICollectionSkinsSender>()
               .WithId(GameConstants.SiteCollectionSdkSkinsSender)
               .To<YandexSiteCollection>()
               .FromResolve();

            Container
                .Bind<ICollectionSkinsProvider>()
                .WithId(GameConstants.SiteCollectionSdkSkinsProvider)
                .To<YandexSiteCollection>()
                .FromResolve();
        }
    }
}