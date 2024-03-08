using Basketball_YG.Model.Signal;

namespace Basketball_YG.Core
{
    public interface IStateSwitcher
    {
        public void Switch(StateSignal next);
    }
}