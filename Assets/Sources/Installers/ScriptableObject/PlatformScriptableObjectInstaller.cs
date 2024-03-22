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

        [Header("Prefab")]
        [SerializeField] private PrefabBallsConfig _ballPrefab;
        
        public override void InstallBindings()
        {
            BindPlatformConfig();
            BindBallConfig();
            BindSpeedomentRewardConfig();

            BindBallSkins();
            BindSiteSkins();

            BinfPrefabBallsConfig();
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
                .BindInstance(_ballSkinData)
                .WithId(GameConstants.BallSkinData);
        }

        private void BindSiteSkins()
        {
            Container
                .BindInstance(_siteSkinData)
                .WithId(GameConstants.SiteSkinData);
        }

        private void BinfPrefabBallsConfig()
        {
            Container
                .BindInstance(_ballPrefab);
        }
    }
}