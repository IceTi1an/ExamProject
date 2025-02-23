using System;
using Game;
using UnityEngine;

namespace SO
{
    [Serializable]
    public record BirdData
    {
        public Action onChanged;

        public string name;
        public bool isDefault;
        public Sprite icon;
        public BirdMoveMent prefab;
    }
}
