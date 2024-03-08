using Basketball_YG.Config;
using SanyaBeer.Meta;
using Zenject;

namespace Basketball_YG.Model
{
    public class ScoreModel
    {
        private readonly TextSetup _scoreText;

        public ScoreModel(
            [InjectOptional(Optional = true, Id = GameConstants.UiMainMenuScoreText)]
            TextSetup scoreText)
        {
            _scoreText = scoreText;
        }
    }
}