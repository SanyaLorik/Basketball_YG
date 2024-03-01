using Basketball_YG.Config;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    [CreateAssetMenu(fileName = "PlatformInstaller", menuName = "Installers/PlatformInstaller")]
    public class PlatformScriptableObjectInstaller : ScriptableObjectInstaller<PlatformScriptableObjectInstaller>
    {
        [SerializeField] private PlatformConfig _platformConfig;
        [SerializeField] private BallConfig _ballConfig;

        public override void InstallBindings()
        {
            BindPlatformConfig();
            BindBallConfig();
        }

        private void BindPlatformConfig()
        {
            Container
                .BindInstance(_platformConfig);
        }

        private void BindBallConfig()
        {
            Container
                .BindInstance(_ballConfig);
        }
    }
}