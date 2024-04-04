using SanyaBeer.Meta.Ui;
using System;
using UnityEngine;

namespace SanyaBeer.Meta
{
    [Serializable]
    public class CheckedBox
    {
        [SerializeField] private DefualtCheckedBox _checkedBox;

        public event Action OnChecked;
        public event Action OnUnchecked;

        public void Initialize()
        {
            _checkedBox.OnChanged += OnHandle;
        }

        public void Dispose()
        {
            _checkedBox.OnChanged -= OnHandle;
        }

        public void AddListenerToChecking(Action action)
        {
            OnChecked += action;
        }

        public void RemoveListenerToChecking(Action action)
        {
            OnChecked -= action;
        }

        public void AddListenerToUnchecking(Action action)
        {
            OnUnchecked += action;
        }

        public void RemoveListenerToUnchecking(Action action)
        {
            OnUnchecked -= action;
        }

        public void SetChecking()
        {
            _checkedBox.SetChecking();
        }

        public void SetUncheking()
        {
            _checkedBox.SetUnchecking();
        }

        private void OnHandle()
        {
            if (_checkedBox.IsChecked == true)
                OnChecked?.Invoke();
            else
                OnUnchecked?.Invoke();
        }
    }
}