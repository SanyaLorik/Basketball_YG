namespace Basketball_YG.Model.Signal
{
    public struct ActivityPauseSignal
    {
        public readonly bool IsOpening;

        public ActivityPauseSignal(bool isOpening)
        {
            IsOpening = isOpening;
        }
    }
}