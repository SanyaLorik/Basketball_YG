using System;
using UnityEngine;

namespace Basketball_YG.Core
{
    public class BoundPointsCalcualor
    {
        private readonly BoundPoints _points;

        public BoundPointsCalcualor(BoundPoints points)
        {
            _points = points;
        }

        public Vector3 CalculateByPosition(Vector3 position, DirectionBoundType direction)
        {
            throw new NotImplementedException();
        }
    }
}