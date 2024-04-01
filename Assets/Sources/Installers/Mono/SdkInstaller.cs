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
                RealConnetionBind();
            else
                FakeConnectionBind();
        }

        private void FakeConnectionBind()
        {
            Container
                .Bind<IContectionStatus>()
                .To<FakeConnectionStatus>()
                .AsCached();
        }

        private void RealConnetionBind()
        {
            throw new NotImplementedException();
        }
    }
}