namespace Basketball_YG.Model.Signal
{
    public struct ActivityBallStoreSignal
    {
        public readonly bool IsOpening;

        public ActivityBallStoreSignal(bool isOpening)
        {
            IsOpening = isOpening;
        }
    }
}