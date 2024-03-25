using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Basketball_YG.Core
{
    public class BoundPointsCalcualor
    {
        private readonly BoundPoints _bound;
        private readonly Dictionary<BoundPointType, int> _long;

        public BoundPointsCalcualor(BoundPoints bound)
        {
            _bound = bound;
            _long = new()
            {
                { BoundPointType.Near, 2 },
                { BoundPointType.Middle, 3 },
                { BoundPointType.Farther, 4 }
            };
        }

        public Vector3 RandomCentre => _bound.Points[_bound.Points.Length / 2 + UnityEngine.Random.Range(-1, 2)];

        public Vector3 CalculateByPosition(Vector3 position, DirectionBoundType direction, BoundPointType bound = BoundPointType.Near)
        {
            if (direction == DirectionBoundType.NoChanching)
                throw new Exception($"Type {direction} does not allow this value!");

            int indexOffset = _long[bound];
            int indexToNearPosition = FindIndexNearPosition(position);
            int index = direction == DirectionBoundType.Left ?
                Math.Clamp(indexToNearPosition + indexOffset, 0, _bound.Points.Length - 1) :
                Math.Clamp(indexToNearPosition - indexOffset, 0, _bound.Points.Length - 1);

            //Debug.Log("indexOffset: " + indexOffset + "\nindexToNearPosition: " + indexToNearPosition + "\nindex: " + index);

            return _bound.Points[index];
        }

        private int FindIndexNearPosition(Vector3 position)
        {
            return _bound.Points
                .Select((p, index) => new { Index = index, Distance = Vector3.Distance(p, position) })
                .OrderBy(x => x.Distance)
                .Select(x => x.Index)
                .FirstOrDefault();
        }
    }

    public enum BoundPointType
    {
        Near = 0,
        Middle,
        Farther
    }
}