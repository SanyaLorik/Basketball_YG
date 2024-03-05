using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SanyaBeer.Meta.Ui
{
    [RequireComponent(typeof(Image))]
    public abstract class DefualtClickedElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Sprite _state1;
        [SerializeField] private Sprite _state2;

        public event Action OnClicked;

        private Vector2 _positionDown = Vector2.zero;

        protected Image Surface { get; private set; }

        protected virtual void Start()
        {
            Surface = GetComponent<Image>();
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            Tap(eventData.position);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            Untap(eventData.position);
        }

        protected void ChangeSpriteToState1()
        {
            ChangeSprite(_state1);
        }

        protected void ChangeSpriteToState2()
        {
            ChangeSprite(_state2);
        }

        private void Tap(Vector2 position)
        {
            _positionDown = position;
        }

        private void Untap(Vector2 position)
        {
            float distance = Vector2.Distance(position, _positionDown);
            if (distance <= UiConstants.DistanceTap)
                OnClicked?.Invoke();
        }

        private void ChangeSprite(Sprite sprite)
        {
            Surface.sprite = sprite;
        }
    }
}