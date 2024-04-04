using UnityEngine;

namespace Basketball_YG.Volume
{
    public class VolumeAudio 
    {
        private readonly AudioSource _source;
        private bool _isPlayed;

        public VolumeAudio(AudioSource source)
        {
            _source = source;
        }

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