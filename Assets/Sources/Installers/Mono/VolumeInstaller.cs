using Basketball_YG.Config;
using Basketball_YG.Volume;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Installer
{
    public class VolumeInstaller : MonoInstaller
    {
        [SerializeField] private List<VolumeEntity> _volumeEntities;
        [SerializeField] private VolumeAudio _music;
        [SerializeField] private VolumeAudio _sound;

        public override void InstallBindings()
        {
            BindVolumeAudio();
            BindVolumeManagement();
        }

        private void BindVolumeManagement()
        {
            IDictionary<VolumeType, AudioClip> volumes = _volumeEntities.ToDictionary(entity => entity.Type, entity => entity.Clip);

            Container
                .Bind<IDictionary<VolumeType, AudioClip>>()
                .FromInstance(volumes)
                .AsCached();

            Container
                .Bind<VolumeManagement>()
                .AsCached();
        }

        private void BindVolumeAudio()
        {
            Container
                .Bind<VolumeAudio>()
                .WithId(GameConstants.VolumeAudioMusic)
                .FromInstance(_music)
                .AsCached();

            Container
                .Bind<VolumeAudio>()
                .WithId(GameConstants.VolumeAudioSound)
                .FromInstance(_sound)
                .AsCached();
        }
    }
}