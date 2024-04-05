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
                BindRealMoneyReciver();
                BindRealMoneySender();
                BindRealScoreReciver();
                BindRealScoreSender();
                BindRealVolume();
                BindRealBallSkinStore();
                BindRealSiteSkinStore();
            }
            else
            {
                BindFakeConnection();
                BindFakeMoneyReciver();
                BindFakeMoneySender();
                BindFakeScoreReciver();
                BindFakeScoreSender();
                BindFakeVolume();
                BindFakeBallSkinStore();
                BindFakeSiteSkinStore();
            }
        }

        private void BindFakeConnection()
        {
            Container
                .BindInterfacesAndSelfTo<FakeConnectionStatus>()
                .AsCached();
        }

        private void BindFakeMoneyReciver()
        {
            Container
                .BindInterfacesAndSelfTo<FakeMoneyReciver>()
                .AsCached();
        }

        private void BindFakeMoneySender()
        {
            Container
                .BindInterfacesAndSelfTo<FakeMoneySender>()
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

        private void BindRealConnetion()
        {
            Container
                .BindInterfacesAndSelfTo<YandexConnectionStatus>()
                .AsCached();
        }

        private void BindRealMoneyReciver()
        {
            Container
                .BindInterfacesAndSelfTo<YandexMoneyReciver>()
                .AsCached();
        }

        private void BindRealMoneySender()
        {
            Container
                .BindInterfacesAndSelfTo<YandexMoneySender>()
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
    }
}