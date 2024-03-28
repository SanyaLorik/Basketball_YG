using System;
using UnityEngine;

namespace SanyaBeer.Meta
{
    [Serializable]
    public class EachElementActivityArray
    {
        [SerializeField] private GameObject[] _elements;

        private int _index;

        public void ShowOne()
        {
            _elements[_index].SetActive(true);
            _index = Math.Clamp(_index - 1, 0, _elements.Length - 1);
        }

        public void HideOne()
        {
            _elements[_index].SetActive(false);
            _index = Math.Clamp(_index + 1, 0, _elements.Length - 1);
        }

        public void ShowAll()
        {
            for (int i = 0; i < _elements.Length; i++)
                _elements[i].SetActive(true);
        }

        public void HideAll()
        {
            for (int i = 0; i < _elements.Length; i++)
                _elements[i].SetActive(false);
        }
    }
}