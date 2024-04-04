using System;
using UnityEngine;

namespace Basketball_YG.Volume
{
    [Serializable]
    public class VolumeAudio 
    {
        [SerializeField] private AudioSource _source;

        private bool _isPlayed;

        public void TurnOn()
        {
            _isPlayed = true;
        }

        public void TurnOff()
        {
            _isPlayed = false;
            _source.Stop();
        }

        public void Play(AudioClip clip)
        {
            if (_isPlayed == false)
                return;

            _source.clip = clip;

            _source.Stop();
            _source.Play();
        }
    }
}