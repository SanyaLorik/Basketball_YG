﻿using System;
using UnityEngine;

namespace SanyaBeer.Meta
{
    [Serializable]
    public struct ElementActivityArray
    {
        [SerializeField] private GameObject[] _menus;

        public void Show()
        {
            for (int i = 0; i < _menus.Length; i++)
                _menus[i].SetActive(true);
        }

        public void Hide()
        {
            for (int i = 0; i < _menus.Length; i++)
                _menus[i].SetActive(false);
        }
    }
}