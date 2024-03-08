namespace Basketball_YG.Model.Signal
{
    public struct ActivitySettingsSignal
    {
        public readonly bool IsOpening;

        public ActivitySettingsSignal(bool isOpening)
        {
            IsOpening = isOpening;
        }
    }
}