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
                RealConnetionBind();
                RealMoneyReciver();
                RealMoneySender();
                RealScoreReciver();
                RealScoreSender();
            }
            else
            {
                FakeConnectionBind();
                FakeMoneyReciver();
                FakeMoneySender();
                FakeScoreReciver();
                FakeScoreSender();
            }
        }

        private void FakeConnectionBind()
        {
            Container
                .BindInterfacesAndSelfTo<FakeConnectionStatus>()
                .AsCached();
        }

        private void FakeMoneyReciver()
        {
            Container
                .BindInterfacesAndSelfTo<FakeMoneyReciver>()
                .AsCached();
        }

        private void FakeMoneySender()
        {
            Container
                .BindInterfacesAndSelfTo<FakeMoneySender>()
                .AsCached();
        }

        private void FakeScoreReciver()
        {
            Container
                .BindInterfacesAndSelfTo<FakeScoreReciver>()
                .AsCached();
        }

        private void FakeScoreSender()
        {
            Container
                .BindInterfacesAndSelfTo<FakeScoreSender>()
                .AsCached();
        }

        private void RealConnetionBind()
        {
            Container
                .BindInterfacesAndSelfTo<YandexConnectionStatus>()
                .AsCached();
        }

        private void RealMoneyReciver()
        {
            Container
                .BindInterfacesAndSelfTo<YandexMoneyReciver>()
                .AsCached();
        }

        private void RealMoneySender()
        {
            Container
                .BindInterfacesAndSelfTo<YandexMoneySender>()
                .AsCached();
        }

        private void RealScoreReciver()
        {
            throw new NotImplementedException();
        }

        private void RealScoreSender()
        {
            throw new NotImplementedException();
        }
    }
}