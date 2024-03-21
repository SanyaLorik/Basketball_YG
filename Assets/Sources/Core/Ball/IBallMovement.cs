using System;

namespace Basketball_YG.Core
{
    public interface IBallMovement
    {
        Action OnHitted { set; }

        Action OnMissed { set; }
    }
}