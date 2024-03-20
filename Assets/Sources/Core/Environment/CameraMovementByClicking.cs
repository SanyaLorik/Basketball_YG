using Basketball_YG.Config;
using SanyaBeer.Meta;
using System;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Core
{
    public struct CameraMovementByClicking : IInitializable, IDisposable
    {
        private readonly ElementActivity _gameplayCameraActivity;
        private readonly ElementActivity _ballSkinCameraActivity;
        private readonly ElementActivity _siteSkinCameraActivity;
        private readonly ClickedCallback _ballSkinMenuButton;
        private readonly ClickedCallback _siteSkinMenuButton;
        private readonly ClickedCallback _ballSkinButton;
        private readonly ClickedCallback _siteSkinButton;

        public CameraMovementByClicking(
            [InjectOptional(Optional = true, Id = GameConstants.GameplayCameraActivity)]
            ElementActivity gameplayCameraActivity,
            [InjectOptional(Optional = true, Id = GameConstants.BallSkinCameraActivity)]
            ElementActivity ballSkinCameraActivity,
            [InjectOptional(Optional = true, Id = GameConstants.SiteSkinCameraActivity)]
            ElementActivity siteSkinCameraActivity,
            [InjectOptional(Optional = true, Id = GameConstants.UiBallStoreMenuButton)]
            ClickedCallback ballSkinMenuButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiSiteStoreMenuButton)]
            ClickedCallback siteSkinMenuButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonBallStore)]
            ClickedCallback ballSkinButton,
            [InjectOptional(Optional = true, Id = GameConstants.UiButtonSiteStore)]
            ClickedCallback siteSkinButton)
        {
            _gameplayCameraActivity = gameplayCameraActivity;
            _ballSkinCameraActivity = ballSkinCameraActivity;
            _siteSkinCameraActivity = siteSkinCameraActivity;
            _ballSkinMenuButton = ballSkinMenuButton;
            _siteSkinMenuButton = siteSkinMenuButton;
            _ballSkinButton = ballSkinButton;
            _siteSkinButton = siteSkinButton;
        }

        public void Initialize()
        {
            _ballSkinButton.AddListner(OnShowOnlyBallSkinCamera);
            _siteSkinButton.AddListner(OnShowOnlySiteSkinCamera);
            _ballSkinMenuButton.AddListner(OnShowOnlyGameplayCamera);
            _siteSkinMenuButton.AddListner(OnShowOnlyGameplayCamera);
        }

        public void Dispose()
        {
            _ballSkinButton.RemoveListener(OnShowOnlyBallSkinCamera);
            _siteSkinButton.RemoveListener(OnShowOnlySiteSkinCamera);
            _ballSkinMenuButton.RemoveListener(OnShowOnlyGameplayCamera);
            _siteSkinMenuButton.RemoveListener(OnShowOnlyGameplayCamera);
        }

        private void OnShowOnlyBallSkinCamera()
        {
            _ballSkinCameraActivity.Show();
            _siteSkinCameraActivity.Hide();
            _gameplayCameraActivity.Hide();
        }

        private void OnShowOnlySiteSkinCamera()
        {
            _ballSkinCameraActivity.Hide();
            _siteSkinCameraActivity.Show();
            _gameplayCameraActivity.Hide();
        }

        private void OnShowOnlyGameplayCamera()
        {
            _ballSkinCameraActivity.Hide();
            _siteSkinCameraActivity.Hide();
            _gameplayCameraActivity.Show();
        }
    }
}