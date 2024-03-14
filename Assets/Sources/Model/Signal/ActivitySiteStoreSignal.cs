namespace Basketball_YG.Model.Signal
{
    public struct ActivitySiteStoreSignal
    {
        public readonly bool IsOpening;

        public ActivitySiteStoreSignal(bool isOpening)
        {
            IsOpening = isOpening;
        }
    }
}