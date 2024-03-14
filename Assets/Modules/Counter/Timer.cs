using Cysharp.Threading.Tasks;
using SanyaBeer.Meta;
using System;
using UnityEngine;

namespace Basketball_YG.Counter
{
    [Serializable]
    public struct Timer
    {
        [SerializeField] private TextSetup _text;
        [SerializeField][Min(0)] private int _time;

        public async UniTask StartTimer()
        {
            const int delay = 1000;

            for (int i = _time; i >= 0; i--)
            {
                _text.SetText(i.ToString());
                await UniTask.Delay(delay);
            }
        }
    }
}