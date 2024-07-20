using Game;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "LevelContainers", menuName = "SO/Lists/Levels")]
    public partial class LevelList : ScriptableObject, ILevelSaveManager
    {
        public Action<LevelData> onLevelSelected { get; set; }

        public List<LevelData> levelsList = null;
        [SerializeField] private LevelData _currentLevel;


        public LevelData GetCurrentLevel()
        {
            string defaultLevelName = "";
            foreach (LevelData level in levelsList)
            {
                defaultLevelName = level.name;
            }
            string savedLevelName = PlayerPrefs.GetString("CurrentLevel", defaultLevelName);
            foreach (LevelData level in levelsList)
            {
                if (level.name == savedLevelName)
                {
                    _currentLevel = level;
                    break;
                }
            }


            return _currentLevel;
        }

        public void SetCurrentLevel(LevelData level)
        {
            _currentLevel = level;

            PlayerPrefs.SetString("CurrentLevel", level.name);

            onLevelSelected?.Invoke(_currentLevel);
        }
    }
}