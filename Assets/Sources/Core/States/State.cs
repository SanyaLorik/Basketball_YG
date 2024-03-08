namespace Basketball_YG.Core
{
    public abstract class State : IState
    {
        public abstract void Disable();

        public abstract void Enable();
    }
}