using Basketball_YG.Config;
using Basketball_YG.Data;
using System;
using UnityEngine;

namespace Basketball_YG.Model
{
    [Serializable]
    public class SkinPrefabStore
    {
        [SerializeField] private SkinCollectionData _collection;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _spawnpoint;

        private GameObject[] _skins;

        public void Spawn()
        {
            SkinStore[] prefabs = _collection.Skins;
            _skins = new GameObject[prefabs.Length];

            for (int i = 0; i < _skins.Length; i++)
                _skins[i] = UnityEngine.Object.Instantiate(prefabs[i].Prefab, _spawnpoint.position, _spawnpoint.rotation, _container);
        }

        public void ShowOnlyCurrentSkin(int index)
        {
            for (int i = 0; i < _skins.Length; i++)
                _skins[i].SetActive(i == index);
        }
    }
}