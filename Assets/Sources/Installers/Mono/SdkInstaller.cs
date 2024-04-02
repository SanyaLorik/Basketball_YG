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
                .Bind<IContectionStatus>()
                .To<FakeConnectionStatus>()
                .AsCached();
        }

        private void FakeMoneyReciver()
        {
            Container
                .Bind<IMoneyReciver>()
                .To<IMoneyReciver>()
                .AsCached();
        }

        private void FakeMoneySender()
        {
            Container
                .Bind<IMoneySender>()
                .To<FakeMoneySender>()
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