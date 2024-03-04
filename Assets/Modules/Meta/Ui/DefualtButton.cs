using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SanyaBeer.Meta.Ui
{
    [RequireComponent(typeof(Image))]
    public class DefualtButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Sprite _normal;
        [SerializeField] private Sprite _pressed;

        public event Action OnClicked;

        private Image _surface;
        private Vector2 _positionDown = Vector2.zero;

        private ColorFader _colorFader;

        private void Start()
        {
            _surface = GetComponent<Image>();
            _colorFader = new ColorFader(GetComponentsInChildren<Graphic>(true));

            ChangeSprite(_normal);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Tap(eventData.position);
            ChangeSprite(_pressed);
            _colorFader.Fade();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Untap(eventData.position);
            ChangeSprite(_normal);
            _colorFader.Unfade();
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
            _surface.sprite = sprite;
        }
    }
}