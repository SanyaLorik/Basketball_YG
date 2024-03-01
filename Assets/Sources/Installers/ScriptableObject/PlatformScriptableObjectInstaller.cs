using Basketball_YG.Config;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    [CreateAssetMenu(fileName = "PlatformInstaller", menuName = "Installers/PlatformInstaller")]
    public class PlatformScriptableObjectInstaller : ScriptableObjectInstaller<PlatformScriptableObjectInstaller>
    {
        [SerializeField] private PlatformConfig _platformConfig;

        public override void InstallBindings()
        {
            BindPlatformConfig();
        }

        private void BindPlatformConfig()
        {
            Container
                .BindInstance(_platformConfig);
        }
    }
}