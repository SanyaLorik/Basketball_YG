using Basketball_YG.Config;
using UnityEngine;
using Zenject;

namespace Basketball_YG.View
{
    public class PlatformView : PositionView
    {
        public PlatformView([InjectOptional(Optional = true, Id = GameConstants.PlatformTransform)] Transform transform) : base(transform) { }
    }
}