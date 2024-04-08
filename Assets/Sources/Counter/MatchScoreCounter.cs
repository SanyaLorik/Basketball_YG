using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using Zenject;

namespace Basketball_YG.Counter
{
    public class MatchScoreCounter : IInitializable, IDisposable
    {
        private readonly TextSetup _text;
        private readonly SignalBus _signalBus;

        private int _counter = 0;

        public int LastCount { get; private set; }

        public MatchScoreCounter(
            [InjectOptional(Optional = true, Id = GameConstants.UiGameplayScoreCounterText)]
            TextSetup textSetup, 
            SignalBus signalBus)
        {
            _text = textSetup;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ScoreSignal>(OnUpdateScore);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ScoreSignal>(OnUpdateScore);
        }

        public void Reload()
        {
            _counter = GameConstants.DefualtScoreCounterValue;
            _text.SetText(GameConstants.DefualtScoreCounterText);
        }

        private void OnUpdateScore(ScoreSignal score)
        {
            _counter += score.Score;
            _text.SetText(_counter.ToString());

            LastCount = _counter;
        }
    }
}