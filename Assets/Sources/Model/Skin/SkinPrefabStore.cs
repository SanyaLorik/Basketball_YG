using Basketball_YG.Config;
using Basketball_YG.Data;
using System;
using System.Linq;
using UnityEngine;

namespace Basketball_YG.Model
{
    [Serializable]
    public class SkinPrefabStore
    {
        [SerializeField] private SkinCollectionData _collection;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _spawnpoint;

        private GameObjectWithId[] _skins;

        public void Spawn()
        {
            SkinStore[] prefabs = _collection.Skins;
            _skins = new GameObjectWithId[prefabs.Length];

            for (int i = 0; i < _skins.Length; i++)
                _skins[i] = new(UnityEngine.Object.Instantiate(prefabs[i].Prefab, _spawnpoint.position, _spawnpoint.rotation, _container), prefabs[i].Id);
        }

        public void ShowOnlyCurrentSkin(int index)
        {
            for (int i = 0; i < _skins.Length; i++)
                _skins[i].Skin.SetActive(i == index);
        }

        public GameObject GetSkinById(int id)
        {
            return _skins.FirstOrDefault(i => i.Id == id).Skin;
        }

        public void ReturnToIntialPositionAllSkins()
        {
            for (int i = 0; i < _skins.Length; i++)
            {
                _skins[i].Skin.transform.SetParent(_container, true);
                _skins[i].Skin.transform.position = _spawnpoint.position;
            }
        }
    }

    public readonly struct GameObjectWithId
    {
        public readonly GameObject Skin;
        public readonly int Id;

        public GameObjectWithId(GameObject skin, int id)
        {
            Skin = skin;
            Id = id;
        }
    }
}