using Basketball_YG.Config;
using SanyaBeer.Meta;
using System;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Core
{
    public struct CameraMovementByClicking : IInitializable, IDisposable
    {
        private readonly Transform _camera;
        private readonly Transform _gameplayCameraPoint;
        private readonly Transform _ballSkinCameraPoint;
        private readonly Transform _siteSkinCameraPoint;
        private readonly ClickedCallback _ballSkinMenuButton;
        private readonly ClickedCallback _siteSkinMenuButton;
        private readonly ClickedCallback _ballSkinButton;
        private readonly ClickedCallback _siteSkinButton;

        public CameraMovementByClicking(
            [InjectOptional(Optional = true, Id = GameConstants.CameraMain)]
            Camera camera,
            [InjectOptional(Optional = true, Id = GameConstants.GameplayCameraPoint)]
            Transform gameplayCameraPoint,
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinCameraPoint)]
            Transform ballSkinCameraPoint,
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinCameraPoint)]
            Transform siteSkinCameraPoint,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreMenuButton)]
            ClickedCallback ballSkinMenuButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreMenuButton)]
            ClickedCallback siteSkinMenuButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonBallStore)]
            ClickedCallback ballSkinButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonSiteStore)]
            ClickedCallback siteSkinButton)
        {
            _camera = camera.transform;
            _gameplayCameraPoint = gameplayCameraPoint;
            _ballSkinCameraPoint = ballSkinCameraPoint;
            _siteSkinCameraPoint = siteSkinCameraPoint;
            _ballSkinMenuButton = ballSkinMenuButton;
            _siteSkinMenuButton = siteSkinMenuButton;
            _ballSkinButton = ballSkinButton;
            _siteSkinButton = siteSkinButton;
        }

        public void Initialize()
        {
            _ballSkinButton.AddListner(OnMoveToBallSkinLocation);
            _siteSkinButton.AddListner(OnMoveToSiteSkinLocation);
            _ballSkinMenuButton.AddListner(OnMoveToMenuLocation);
            _siteSkinMenuButton.AddListner(OnMoveToMenuLocation);
        }

        public void Dispose()
        {
            _ballSkinButton.RemoveListener(OnMoveToBallSkinLocation);
            _siteSkinButton.RemoveListener(OnMoveToSiteSkinLocation);
            _ballSkinMenuButton.RemoveListener(OnMoveToMenuLocation);
            _siteSkinMenuButton.RemoveListener(OnMoveToMenuLocation);
        }

        private void OnMoveToBallSkinLocation()
        {
            throw new NotImplementedException();
        }

        private void OnMoveToSiteSkinLocation()
        {
            throw new NotImplementedException();
        }

        private void OnMoveToMenuLocation()
        {
            throw new NotImplementedException();
        }
    }
}