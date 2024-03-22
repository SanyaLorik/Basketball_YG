using Basketball_YG.Wrapper;
using System;
using UnityEngine;

namespace Basketball_YG.Core
{
    [Serializable]
    public struct BallSpawner
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _spawnpoint;

        public BallWrapper Spawn(BallWrapper prefab)
        {
            return UnityEngine.Object.Instantiate(prefab, _spawnpoint.position, _spawnpoint.rotation, _container);
        }
    }
}