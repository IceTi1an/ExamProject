using SO;
using System;
using static SO.BirdList;

namespace Interfaces
{
    public interface IBirdSaveManager
    {
        public Action<BirdData> onBirdSelected { get; set; }

        public BirdData GetCurrentBird();

        public void SetCurrentBird(BirdData bird);
    }
}