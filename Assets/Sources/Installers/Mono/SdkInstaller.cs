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
            }
            else
            {
                FakeConnectionBind();
                FakeMoneyReciver();
                FakeMoneySender();
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

        private void RealConnetionBind()
        {
            throw new NotImplementedException();
        }

        private void RealMoneyReciver()
        {
            throw new NotImplementedException();
        }

        private void RealMoneySender()
        {
            throw new NotImplementedException();
        }
    }
}