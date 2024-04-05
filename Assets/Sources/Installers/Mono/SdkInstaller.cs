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
                .Bind<ICurrentSkinProvider>()
                .WithId(GameConstants.BallSkinStoreSdkProvider)
                .To<FakeBallSkin>()
                .AsCached();

            Container
                .Bind<ICurrentSkinSender>()
                .WithId(GameConstants.BallSkinStoreSdkSender)
                .To<FakeBallSkin>()
                .AsCached();

            Container
                .BindInterfacesTo<FakeBallSkin>()
                .AsCached();
        }

        private void BindFakeSiteSkinStore()
        {
            Container
                .Bind<ICurrentSkinProvider>()
                .WithId(GameConstants.SiteSkinStoreSdkProvider)
                .To<FakeSiteSkin>()
                .AsCached();

            Container
                .Bind<ICurrentSkinSender>()
                .WithId(GameConstants.SiteSkinStoreSdkSender)
                .To<FakeSiteSkin>()
                .AsCached();

            Container
                .BindInterfacesTo<FakeSiteSkin>()
                .AsCached();
        }

        private void BindRealConnetion()
        {
            throw new NotImplementedException();
        }

        private void BindRealMoneyReciver()
        {
            throw new NotImplementedException();
        }

        private void BindRealMoneySender()
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
    }
}