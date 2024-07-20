using SO;
using System;

namespace Interfaces
{
    public interface ILevelSaveManager
    {
        public Action<LevelData> onLevelSelected { get; set; }

        public LevelData GetCurrentLevel();
        public void SetCurrentLevel(LevelData level);
    }
}