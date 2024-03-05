using SanyaBeer.Meta.Ui;
using System;
using UnityEngine;

namespace SanyaBeer.Meta
{
    [Serializable]
    public struct ClickedCallback
    {
        [SerializeField] private DefualtClickedElement _button;

        public void AddListner(Action action)
        {
            _button.OnClicked += action;
        }

        public void RemoveListener(Action action)
        {
            _button.OnClicked -= action;
        }
    }
}