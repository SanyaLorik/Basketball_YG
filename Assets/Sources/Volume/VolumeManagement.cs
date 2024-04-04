using Basketball_YG.Sdk;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Volume
{
    public class VolumeManagement : IInitializable
    {
        private readonly IDictionary<VolumeType, AudioClip> _volumes;
        private readonly IVolumeProvider _volumeProvider;
        private readonly VolumeAudio _music;
        private readonly VolumeAudio _sound;

        public VolumeManagement(IDictionary<VolumeType, AudioClip> volumes, IVolumeProvider volumeProvider, VolumeAudio music, VolumeAudio sound)
        {
            _volumes = volumes;
            _volumeProvider = volumeProvider;
            _music = music;
            _sound = sound;
        }

        public void Initialize()
        {
            if (_volumeProvider.IsActivedSound == true)
                TurnOnSound();
            else
                TurnOffSound();

            if (_volumeProvider.IsActivedMusic == true)
                TurnOnMusic();
            else
                TurnOffMusic();
        }

        public void TurnOnSound()
        {
            _sound.TurnOn();
        }

        public void TurnOffSound()
        {
            _sound.TurnOff();
        }

        public void TurnOnMusic()
        {
            _music.TurnOn();
        }

        public void TurnOffMusic()
        {
            _music.TurnOff();
        }
    }
}