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
            throw new NotImplementedException();
        }

        private void BindRealMoney()
        {
            throw new NotImplementedException();
        }

        private void BindRealScoreReciver()
        {
            throw new NotImplementedException();
        }

        private void BindRealScoreSender()
        {
            throw new NotImplementedException();
        }

        private void BindRealVolume()
        {
            throw new NotImplementedException();
        }

        private void BindRealBallSkinStore()
        {
            throw new NotImplementedException();
        }

        private void BindRealSiteSkinStore()
        {
            throw new NotImplementedException();
        }

        private void BindRealBallCollectionSkins()
        {
            throw new NotImplementedException();
        }

        private void BindRealSiteCollectionSkins()
        {
            throw new NotImplementedException();
        }

    }
}