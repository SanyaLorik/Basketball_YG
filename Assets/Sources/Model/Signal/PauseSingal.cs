namespace Basketball_YG.Model.Signal
{
    public struct PauseSingal
    {
        public readonly PauseType Type;

        public PauseSingal(PauseType type)
        {
            Type = type;
        }

        public enum PauseType
        {
            Pause = 0,
            Unpause
        }
    }
}