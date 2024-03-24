using SanyaBeer.Additional;
using System;
using UnityEngine;

namespace Basketball_YG.Core
{
    public class BoundPointsCalcualor
    {
        private readonly BoundPoints _bound;

        public BoundPointsCalcualor(BoundPoints bound)
        {
            _bound = bound;
        }

        public Vector3 CalculateByPosition(Vector3 position, DirectionBoundType direction)
        {
            return _bound.Points.GetRandomElement();
        }
    }
}