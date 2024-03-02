﻿using Basketball_YG.Config;
using Basketball_YG.Meta;
using Zenject;

namespace Basketball_YG.Model
{
    public class ScoreModel
    {
        private readonly TextSetup _scoreText;

        public ScoreModel(
            [InjectOptional(Optional = true, Id = GameConstants.UiScoreText)]
            TextSetup scoreText)
        {
            _scoreText = scoreText;
        }
    }
}