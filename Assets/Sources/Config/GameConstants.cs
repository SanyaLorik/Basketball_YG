﻿namespace Basketball_YG.Config
{
    public static class GameConstants
    {
        // Platfrom Movement
        public const float MaxDistanceRaycasting = 128f;
        public const string WallMask = "WallMask";

        // Ball
        public const float AngelBlock = 104f;
        public const float RatioNear = 0.2f;
        public const float RatioCentre = 0.8f; // 0.8 - 1.0 - Farther of ratio 

        // Camera
        public const string CameraMain = "CameraMain";
        public const string GameplayCameraActivity = "GameplayCameraActivity";
        public const string BallSkinCameraActivity = "BallSkinCameraActivity";
        public const string SiteSkinCameraActivity = "SiteSkinCameraActivity";

        // Skins
        public const string BallSkinData = "BallSkinData";
        public const string SiteSkinData = "SiteSkinData";
        public const string BallSkinSelector = "BallSkinSelector";
        public const string SiteSkinSelector = "SiteSkinSelector";
        public const string BallSkinSelectingView = "BallSkinSelectingView";
        public const string SiteSkinSelectingView = "SiteSkinSelectingView";
        public const string BallSkinPrefabStore = "BallSkinPrefabStore";
        public const string SiteSkinPrefabStore = "SiteSkinPrefabStore";
        public const string SitePosition = "SitePosition";

        // Sdk Skins
        public const string BallSkinStoreSdkProvider = "BallSkinStoreSdkProvider";
        public const string BallSkinStoreSdkSender = "BallSkinStoreSdkSender";
        public const string SiteSkinStoreSdkSender = "SiteSkinStoreSdkSender";
        public const string SiteSkinStoreSdkProvider = "SiteSkinStoreSdkProvider";
        public const string BallCollectionSdkSkinsProvider = "BallCollectionSdkSkinsProvider";
        public const string BallCollectionSdkSkinsSender = "BallCollectionSdkSkinsSender";
        public const string SiteCollectionSdkSkinsProvider = "SiteCollectionSdkSkinsProvider";
        public const string SiteCollectionSdkSkinsSender = "SiteCollectionSdkSkinsSender";

        // Platfrom
        public const string PlatfromTouchInput = "PlatfromTouchInput";
        public const string PlatformTransform = "PlatformTransform";
        public const string PlatformView = "PlatformView";
        public const string PlatformModel = "PlatformModel";
        public const string PlatformMovementRangeValues = "PlatformMovementRangeValues";
        public const string PlatformSurfaceRangeValues = "PlatformSurfaceRangeValues";

        // Volume
        public const string VolumeAudioSound = "VolumeAudioSound";
        public const string VolumeAudioMusic = "VolumeAudioMusic";

        // Defualt Ui
        public const string DefualtScoreCounterText = "0";
        public const int DefualtScoreCounterValue = 0;

        // Ui Boostrap Menu
        public const string UiBoostrapMenuActivity = "UiBoostrapMenuActivity";
        public const string UiBoostrapMenu = "UiBoostrapMenu";

        // Ui Main Menu
        public const string UiButtonStartMath = "UiButtonStartMath";
        public const string UiButtonBallStore = "UiButtonBallStore";
        public const string UiButtonSiteStore = "UiButtonSiteStore";
        public const string UiButtonSettingsOpener = "UiButtonSettingsOpener";
        public const string UiButtonGameSharing = "UiButtonGameSharing";
        public const string UiMainMenuScoreText = "UiMainMenuScoreText";
        public const string UiMainMenuMoneyText = "UiMainMenuMoneyText";
        public const string UiMainMenuActivity = "UiMainMenuActivity";
        public const string UiMainMenu = "UiMainMenu";

        // Ui Settings Menu
        public const string UiSettingsMenu = "UiSettingsMenu";
        public const string UiSettingsMenuActivity = "UiSettingsMenuActivity";
        public const string UiButtonCloseSettingsMenu = "UiButtonCloseSettingsMenu";
        public const string UiCheckboxSoundMenu = "UiCheckboxSoundMenu";
        public const string UiCheckboxMusicMenu = "UiCheckboxMusicMenu";

        // Ui Gameplay Menu
        public const string UiGameplayMenu = "UiGameplayMenu";
        public const string UiGameplayMenuActivity = "UiGameplayMenuActivity";
        public const string UiGameplayTimerActivity = "UiGameplayTimerActivity";
        public const string UiButtonGameplayPauseOpener = "UiButtonPauseOpener";
        public const string UiGameplayPrestartMatchActivities = "UiGameplayPrestartMatchActivities";
        public const string UiGameplayScoreCounterText = "UiGameplayScoreCounterText";
        public const string HealthBarElementArray = "HealthBarElementArray";

        // Ui Pause Menu
        public const string UiPauseMenu = "UiPauseMenu";
        public const string UiPauseMenuActivity = "UiPauseMenuActivity";
        public const string UiButtonClosePauseMenu = "UiButtonClosePauseMenu";
        public const string UiButtonHomePauseMenu = "UiButtonContinuePauseMenu";
        public const string UiButtonRestartPauseMenu = "UiButtonRestartPauseMenu";

        // Ui Ball Skin Menu
        public const string UiBallStoreMenu = "UiBallStoreMenu";
        public const string UiBallStoreMenuActivity = "UiBallStoreMenuActivity";
        public const string UiBallStoreNextButton = "UiBallStoreNextButton";
        public const string UiBallStoreBackButton = "UiBallStoreBackButton";
        public const string UiBallStoreSelectedButton = "UiBallStoreSelectedButton";
        public const string UiBallStoreBoughtButton = "UiBallStoreBoughtButton";
        public const string UiBallStoreVideoButton = "UiBallStoreVideoButton";
        public const string UiBallStoreMenuButton = "UiBallStoreMenuButton";
        public const string UiBallStoreSelectedActivity = "UiBallStoreSelectedActivity";
        public const string UiBallStoreBoughtActivity = "UiBallStoreBuyActivity";
        public const string UiBallStoreVideoActivity = "UiBallStoreVideoActivity";
        public const string UiBallStoreNamingText = "UiBallStoreNamingText";
        public const string UiBallStoreMoneyText = "UiBallStoreMoneyText";
        public const string UiBallStoreTotalMoneyText = "UiBallStoreTotalMoneyText";
        public const string UiBallStoreSkinPriceText = "UiBallStoreSkinPriceText";

        // Ui Site Skin Menu
        public const string UiSiteStoreMenu = "UiSiteStoreMenu";
        public const string UiSiteStoreMenuActivity = "UiSiteStoreMenuActivity";
        public const string UiSiteStoreNextButton = "UiSiteStoreNextButton";
        public const string UiSiteStoreBackButton = "UiSiteStoreBackButton";
        public const string UiSiteStoreSelectedButton = "UiSiteStoreSelectedButton";
        public const string UiSiteStoreBoughtButton = "UiSiteStoreBoughtButton";
        public const string UiSiteStoreVideoButton = "UiSiteStoreVideoButton";
        public const string UiSiteStoreMenuButton = "UiSiteStoreMenuButton";
        public const string UiSiteStoreSelectedActivity = "UiSiteStoreSelectedActivity";
        public const string UiSiteStoreBoughtActivity = "UiSiteStoreBuyActivity";
        public const string UiSiteStoreVideoActivity = "UiSiteStoreVideoActivity";
        public const string UiSiteStoreNamingText = "UiSiteStoreNamingText";
        public const string UiSiteStoreMoneyText = "UiSiteStoreMoneyText";
        public const string UiSiteStoreTotalMoneyText = "UiSiteStoreTotalMoneyText";
        public const string UiSiteStoreSkinPriceText = "UiSiteStoreSkinPriceText";

        // Ui Extralife Menu
        public const string UiExtralifeMenu = "UiExtralifeMenu";
        public const string UiExtralifeMenuActivity = "UiExtralifeMenuActivity";
        public const string UiExtralifeButton = "UiExtralifeButton";
        public const string UiCancelExtralifeButton = "UiCancelExtralifeButton";

        // Ui End Menu
        public const string UiEndMenu = "UiEndMenu";
        public const string UiEndActivity = "UiEndActivity";

        // Ui Subend Menu
        public const string UiSubendMenu = "UiSubendMenu";
        public const string UiSubendActivity = "UiSubendActivity";
        public const string UiSubendHomeButton = "UiSubendHomeButton";
        public const string UiSubendRestartButton = "UiSubendRestartButton";
        public const string UiSubendCounText = "UiSubendCounText";

        // Speedometr Reward
        public const string RewardSpeedometrArrow = "RewardSpeedometrArrow";
        public const string SpeedometrMultiplayerSlot = "SpeedometrMultiplayerSlot";
        public const string SpeedometrRewardmoneyText = "SpeedomentRewardmoneyText";
        public const string SpeedometrView = "SpeedomentView";
        public const string SpeedometrRotationModel = "SpeedomentRotationModel";
        public const string SpeedometrInformationModel = "SpeedomentRotationModel";
        public const string UiButtonStopSpeedometr = "UiButtonStopSpeedometr";

        // Money
        public const string MoneyMatch = "MoneyMatch";

        // States
        public const string BoostrapMenu = "BoostrapMenu";
        public const string StateMainMenu = "StateMainMenu";
        public const string StateGameplay = "StateGameplay";
        public const string StateEnd = "StateEnd";
    }
}