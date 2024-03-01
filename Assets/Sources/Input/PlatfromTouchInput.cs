using Basketball_YG.Config;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Basketball_YG.Input
{
    public class PlatfromTouchInput : IPaltformInputService, IInitializable, IDisposable
    {
        private readonly Camera _camera;
        private readonly LayerMask _wallMask;
        private readonly EventTrigger _surface;

        private EventTrigger.Entry _clickedEntry = new() { eventID = EventTriggerType.PointerClick };
        private EventTrigger.Entry _draggedEntry = new() { eventID = EventTriggerType.Drag };

        public PlatfromTouchInput(
            [InjectOptional(Optional = true, Id = GameConstants.CameraMain)] Camera camera,
            [InjectOptional(Optional = true, Id = GameConstants.WallMask)] LayerMask wallMask,
            [InjectOptional(Optional = true, Id = GameConstants.PlatfromTouchInput)] EventTrigger surface)
        {
            _camera = camera;
            _wallMask = wallMask;
            _surface = surface;
        }

        public float TargetX { get; private set; } = 0;

        public void Initialize()
        {
            _clickedEntry.callback.AddListener(OnPointerClick);
            _surface.triggers.Add(_clickedEntry);

            _draggedEntry.callback.AddListener(OnDrag);
            _surface.triggers.Add(_draggedEntry);
        }

        public void Dispose()
        {
            _clickedEntry.callback.RemoveAllListeners();
            _surface.triggers.Remove(_clickedEntry);

            _draggedEntry.callback.RemoveAllListeners();
            _surface.triggers.Remove(_draggedEntry);
        }

        public void OnPointerClick(BaseEventData eventData)
        {
            CalculateTarget(((PointerEventData)eventData).position);
        }

        public void OnDrag(BaseEventData eventData)
        {
            CalculateTarget(((PointerEventData)eventData).position);
        }

        private void CalculateTarget(Vector2 screenPosition)
        {
            var ray = _camera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit, GameConstants.MaxDistanceRaycasting, _wallMask) == true)
                TargetX = hit.point.x;
        }
    }
}