using Game.UI;
using SO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class MainMenu_State : GameState
    {
        [Inject] public UIFactory _uiFactory;

        private UIBase _uiContainer;

        private MainMenu_UI _mainMenu_UI;
        private ShopMenu_UI _shopMenu_UI;
        private LevelMenu_UI _levelMenu_UI;

        public override void Enter()
        {
            InjectService.Inject(this);
            SceneManager.LoadSceneAsync("MainMenu").completed += async (_) =>
            {
                _mainMenu_UI = _uiFactory.GetUI<MainMenu_UI>() as MainMenu_UI;
                _shopMenu_UI = _uiFactory.GetUI<ShopMenu_UI>() as ShopMenu_UI;
                _levelMenu_UI = _uiFactory.GetUI<LevelMenu_UI>() as LevelMenu_UI;

                OpenMainMenu();

                _mainMenu_UI.playButton.onClick.AddListener(GoToGamePlay);
                _mainMenu_UI.levelButton.onClick.AddListener(OpenLevels);
                _mainMenu_UI.shopButton.onClick.AddListener(OpenShopMenu);

                _shopMenu_UI.exitButton.onClick.AddListener(OpenMainMenu);

                _levelMenu_UI.backButton.onClick.AddListener(OpenMainMenu);
            };
        }
        private void GoToGamePlay()
        {
            gameStateChanger.ChangeState(new GamePlayState());
        }
        private void OpenMainMenu()
        {
            _mainMenu_UI.gameObject.SetActive(true);
            _shopMenu_UI.gameObject.SetActive(false);
            _levelMenu_UI.gameObject.SetActive(false);
        }
        private void OpenShopMenu()
        {
            _mainMenu_UI.gameObject.SetActive(false);
            _shopMenu_UI.gameObject.SetActive(true);
            _levelMenu_UI.gameObject.SetActive(false);
        }
        private void OpenLevels()
        {
            _mainMenu_UI.gameObject.SetActive(false);
            _shopMenu_UI.gameObject.SetActive(false);
            _levelMenu_UI.gameObject.SetActive(true);
        }
    }

}