namespace Basketball_YG.Mediator
{
    public abstract class State : IState
    {
        public abstract void Disable();

        public abstract void Enable();
    }
}