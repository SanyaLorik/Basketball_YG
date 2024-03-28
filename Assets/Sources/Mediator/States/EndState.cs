using Basketball_YG.CompositeRoot;
using Basketball_YG.Config;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Mediator
{
    public class EndState : State
    {
        private readonly IMenuActivity _endMenu;
        private readonly IMenuActivity _extraLifeMenu;
        private readonly IMenuActivity _subendMenu;

        public EndState(
             [InjectOptional(Optional = true, Id = GameConstants.UiEndMenu)]
             IMenuActivity endMenu,
             [InjectOptional(Optional = true, Id = GameConstants.UiExtralifeMenu)]
             IMenuActivity extraLifeMenu,
             [InjectOptional(Optional = true, Id = GameConstants.UiSubendMenu)]
             IMenuActivity subendMenu)
        {
            _endMenu = endMenu;
            _extraLifeMenu = extraLifeMenu;
            _subendMenu = subendMenu;
        }

        public override void Enable()
        {
            _endMenu.Show();
            _extraLifeMenu.Show();
            _subendMenu.Hide();
        }

        public override void Disable()
        {
            _endMenu.Hide();
        }
    }
}
