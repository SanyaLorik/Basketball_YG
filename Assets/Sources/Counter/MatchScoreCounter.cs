using Basketball_YG.Config;
using Basketball_YG.Model.Signal;
using SanyaBeer.Meta;
using System;
using System.Diagnostics;
using Zenject;

namespace Basketball_YG.Counter
{
    public class MatchScoreCounter : IInitializable, IDisposable
    {
        private readonly TextSetup _text;
        private readonly SignalBus _signalBus;

        public int Counter { get; private set; } = 0;

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

        private void OnUpdateScore(ScoreSignal score)
        {
            Counter += score.Score;
            _text.SetText(Counter.ToString());
        }
    }
}