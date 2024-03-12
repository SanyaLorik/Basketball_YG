using Zenject;

namespace Basketball_YG.Core
{
    public abstract class Ball : ITickable
    {
        private readonly IBallMovement _movement;

        public Ball(IBallMovement movement)
        {
            _movement = movement;
        }

        public void Tick()
        {
            _movement.Tick();
        }
    }
}