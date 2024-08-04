using Game.UI;
using Interfaces;
using SO;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class GamePlayState : GameState
    {
        [Inject] public UIFactory _uiFactory;

        [Inject] public IBirdSaveManager _birdSaveManager;

        [Inject] public ILevelSaveManager _levelSaveManager;

        private GamePlay_UI _gamePlay_UI;

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

                /*_gamePlay_UI = _uiFactory.GetUI<GamePlay_UI>() as GamePlay_UI;
                _gamePlay_UI.exitButton.onClick.AddListener(Exit);*/
            };
        }
        private void Exit()
        {
            gameStateChanger.ChangeState(new MainMenu_State());
        }
    }

}