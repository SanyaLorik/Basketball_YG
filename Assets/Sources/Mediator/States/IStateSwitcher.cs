using Basketball_YG.Model.Signal;

namespace Basketball_YG.Mediator
{
    public interface IStateSwitcher
    {
        public void Switch(StateSignal next);
    }
}