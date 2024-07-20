using System;
using UnityEngine;

namespace SO
{
    [Serializable]
    public record LevelData
    {
        public Action onChanged;

        public string name;
        public bool isDefault;
        public Sprite icon;
        public GameObject prefab;
    }
}