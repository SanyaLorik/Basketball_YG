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
            }
            else
            {
                BindFakeConnection();
                BindFakeMoneyReciver();
                BindFakeMoneySender();
                BindFakeScoreReciver();
                BindFakeScoreSender();
                BindFakeVolume();
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
    }
}