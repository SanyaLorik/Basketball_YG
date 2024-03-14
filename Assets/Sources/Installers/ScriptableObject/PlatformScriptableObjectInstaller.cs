using Basketball_YG.Config;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    [CreateAssetMenu(fileName = "PlatformInstaller", menuName = "Installers/PlatformInstaller")]
    public class PlatformScriptableObjectInstaller : ScriptableObjectInstaller<PlatformScriptableObjectInstaller>
    {
        [Header("Configs")]
        [SerializeField] private PlatformConfig _platformConfig;
        [SerializeField] private BallConfig _ballConfig;
        [SerializeField] private RewardSpeedometrConfig _speedomentRewardConfig;

        [Header("Skins")]
        [SerializeField] private SkinCollectionData _ballSkinData;
        [SerializeField] private SkinCollectionData _siteSkinData;

        public override void InstallBindings()
        {
            BindPlatformConfig();
            BindBallConfig();
            BindSpeedomentRewardConfig();

            BindBallSkins();
            BindSiteSkins();
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

        private void BindSpeedomentRewardConfig()
        {
            Container
                .BindInstance(_speedomentRewardConfig);
        }

        private void BindBallSkins()
        {
            Container
                .BindInstance(_ballSkinData);
        }

        private void BindSiteSkins()
        {
            Container
                .BindInstance(_siteSkinData);
        }
    }
}