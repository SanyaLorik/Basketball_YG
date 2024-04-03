using Basketball_YG.CompositeRoot;
using Basketball_YG.Config;
using Basketball_YG.Counter;
using Basketball_YG.Sdk;
using UnityEngine;
using Zenject;

namespace Basketball_YG.Mediator
{
    public class EndState : State
    {
        private readonly IMenuActivity _endMenu;
        private readonly IMenuActivity _extraLifeMenu;
        private readonly IMenuActivity _subendMenu;
        private readonly IScoreSender _scoreSender;
        private readonly MatchScoreCounter _matchScore;

        public EndState(
             [InjectOptional(Optional = true, Id = GameConstants.UiEndMenu)]
             IMenuActivity endMenu,
             [InjectOptional(Optional = true, Id = GameConstants.UiExtralifeMenu)]
             IMenuActivity extraLifeMenu,
             [InjectOptional(Optional = true, Id = GameConstants.UiSubendMenu)]
             IMenuActivity subendMenu,
             IScoreSender scoreSender,
             MatchScoreCounter matchScore)
        {
            _endMenu = endMenu;
            _extraLifeMenu = extraLifeMenu;
            _subendMenu = subendMenu;
            _matchScore = matchScore;
            _scoreSender = scoreSender;
        }

        public override void Enable()
        {
            _endMenu.Show();
            _extraLifeMenu.Show();
            _subendMenu.Hide();
        }

        public override void Disable()
        {
            _scoreSender.SendScore(_matchScore.LastCount);
            _endMenu.Hide();
        }
    }
}
