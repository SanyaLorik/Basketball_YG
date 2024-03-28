using Basketball_YG.CompositeRoot;
using Basketball_YG.Config;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Mediator
{
    public class EndState : State
    {
        private readonly IMenuActivity _menuActivity;

        public EndState(
             [InjectOptional(Optional = true, Id = GameConstants.UiEndMenu)]
            IMenuActivity menuActivity)
        {
            Debug.Log(menuActivity);
            _menuActivity = menuActivity;
        }

        public override void Enable()
        {
            _menuActivity.Show();
            Debug.Log("_menuActivity.Show()");

        }

        public override void Disable()
        {
            throw new System.NotImplementedException();
        }
    }
}
