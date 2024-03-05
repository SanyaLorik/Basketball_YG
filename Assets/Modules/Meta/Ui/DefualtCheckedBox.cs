using UnityEngine;
using UnityEngine.UI;

namespace SanyaBeer.Meta.Ui
{
    [RequireComponent(typeof(Image))]
    public class DefualtCheckedBox : DefualtClickedElement
    {
        private bool _isChecked = true;

        private void OnEnable()
        {
            OnClicked += OnChangeState;
        }

        private void OnDisable()
        {
            OnClicked -= OnChangeState;
        }

        private void OnChangeState()
        {
            if (_isChecked == true)
                ChangeSpriteToState2();
            else
                ChangeSpriteToState1();

            _isChecked = !_isChecked;
        }
    }
}