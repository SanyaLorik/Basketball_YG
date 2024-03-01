using Basketball_YG.Config;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    public class EnvironmentInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camerMain;

        public override void InstallBindings()
        {
            BindCamera();
        }

        private void BindCamera()
        {
            Container
                .Bind<Camera>()
                .WithId(GameConstants.CameraMain)
                .FromInstance(_camerMain);
        }
    }
}