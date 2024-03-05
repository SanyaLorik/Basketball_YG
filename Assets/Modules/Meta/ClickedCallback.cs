using SanyaBeer.Meta.Ui;
using System;
using UnityEngine;

namespace SanyaBeer.Meta
{
    [Serializable]
    public struct ClickedCallback
    {
        [SerializeField] private DefualtClickedElement _clicked;

        public void AddListner(Action action)
        {
            _clicked.OnClicked += action;
        }

        public void RemoveListener(Action action)
        {
            _clicked.OnClicked -= action;
        }
    }
}