using System;
using TMPro;
using UnityEngine;

namespace SanyaBeer.Meta
{
    [Serializable]
    public struct TextSetup
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}