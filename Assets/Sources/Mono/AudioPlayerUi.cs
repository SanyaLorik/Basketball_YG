using Basketball_YG.Volume;
using SanyaBeer.Meta.Ui;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Mono
{
    public class AudioPlayerUi : MonoBehaviour
    {
        private DefualtClickedElement[] _elements;
        private VolumeManagement _volumeManagement;

        [Inject]
        private void Construct(VolumeManagement volumeManagement)
        {
            _volumeManagement = volumeManagement;
        }

        private void Start()
        {
            _elements = FindObjectsOfType<DefualtClickedElement>(true);

            for (int i = 0; i < _elements.Length; i++)
                _elements[i].OnClicked += OnPlayButtonSound;
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _elements.Length; i++)
                _elements[i].OnClicked -= OnPlayButtonSound;
        }

        private void OnPlayButtonSound()
        {
            _volumeManagement.PlaySound(VolumeType.ClickedSounds);
        }
    }
}