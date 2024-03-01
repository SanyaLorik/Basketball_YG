using System;
using UnityEngine;
using UnityEngine.UI;

namespace Basketball_YG.Meta
{
    [Serializable]
    public struct ClickedCallback
    {
        [SerializeField] private Button _button;

        public void AddListner(Action action)
        {
            _button.onClick.AddListener(action.Invoke);
        }

        public void RemoveListener(Action action)
        {
            _button.onClick.RemoveListener(action.Invoke);
        }
    }
}