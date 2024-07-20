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

        private bool activeSpawning = false;

        
        public override void Enter()
        {
            InjectService.Inject(this);
            SceneManager.LoadSceneAsync("GamePlay").completed += async (_) =>
            {
                _currentBirdData = _birdSaveManager.GetCurrentBird();
                UnityEngine.Object.Instantiate(_currentBirdData.prefab);

                _currentLevelData = _levelSaveManager.GetCurrentLevel();

                activeSpawning = true;

                /*while(activeSpawning)
                {
                    await Task.Delay(2000);
                    Spawn();
                }   */             
            };
        }

        private void Spawn()
        {
           /* GameObject pipes = UnityEngine.Object.Instantiate(_pipes, Vector3.up * Random.Range(_minHeght, _maxHeght), Quaternion.identity);*/
        }
       
        /*public override void Exit()
        {
            activeSpawning = false;
        }*/
    }

}