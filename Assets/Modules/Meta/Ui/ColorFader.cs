using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SanyaBeer.Meta.Ui
{
    public readonly struct ColorFader
    {
        private readonly IEnumerable<PairInitalColorWithGraphic> _pair;

        public ColorFader(IReadOnlyList<Graphic> graphics)
        {
            PairInitalColorWithGraphic[] pair = new PairInitalColorWithGraphic[graphics.Count];
            for (int i = 0; i < graphics.Count; i++)
                pair[i] = new PairInitalColorWithGraphic(graphics[i], graphics[i].color);

            _pair = pair;
        }

        public void Fade()
        {
            foreach (var pair in _pair)
            {
                Color color = pair.Color;
                color.r -= UiConstants.TapDarkReducing;
                color.g -= UiConstants.TapDarkReducing;
                color.b -= UiConstants.TapDarkReducing;

                pair.Color = color;
            }
        }

        public void Unfade() 
        {
            foreach (var pair in _pair)
                pair.ResetColor();
        }

        private readonly struct PairInitalColorWithGraphic
        {
            public readonly Color InitalColor;
            private readonly Graphic _graphic;

            public PairInitalColorWithGraphic(Graphic graphic, Color initalColor)
            {
                _graphic = graphic;
                InitalColor = initalColor;
            }

            public Color Color { get => _graphic.color; set => _graphic.color = value; }

            public void ResetColor()
            {
                _graphic.color = InitalColor;
            }
        }
    }
}