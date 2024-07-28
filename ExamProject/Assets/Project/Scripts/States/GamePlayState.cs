using Game.UI;
using Interfaces;
using SO;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Game
{
    public class GamePlayState : GameState
    {
        [Inject] public UIFactory _uiFactory;

        [Inject] public IBirdSaveManager _birdSaveManager;

        [Inject] public ILevelSaveManager _levelSaveManager;

        private BirdData _currentBirdData;

        private LevelData _currentLevelData;

        
        public override void Enter()
        {
            InjectService.Inject(this);
            SceneManager.LoadSceneAsync("GamePlay").completed += async (_) =>
            {
                _currentBirdData = _birdSaveManager.GetCurrentBird();
                UnityEngine.Object.Instantiate(_currentBirdData.prefab);

                _currentLevelData = _levelSaveManager.GetCurrentLevel();
                UnityEngine.Object.Instantiate(_currentLevelData.prefab);
            };
        }
    }

}