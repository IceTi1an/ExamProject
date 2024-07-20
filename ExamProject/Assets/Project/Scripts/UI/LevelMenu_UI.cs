using SO;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    public class LevelMenu_UI : UIBase
    {
        public Button backButton;
        public Transform levelContainer;
        public LevelShop_Unit levelShop_Unit;

        [Inject] private LevelList levelList;

        private void Awake()
        {
            InjectService.Inject(this);

            ClearLevels();
            SpawnLevels();
        }

        /*public CarData GetCurrentCar()
        {
            string carName = PlayerPrefs
        }*/

        private void ClearLevels()
        {

            foreach (var level in levelContainer.GetComponentsInChildren<LevelShop_Unit>(true))
            {
                Destroy(level.gameObject);
            }
        }

        private void SpawnLevels()
        {
            foreach (var level in levelList.levelsList)
            {
                var levelShopUnitPrefabCopy = Instantiate(levelShop_Unit, levelContainer);
                levelShopUnitPrefabCopy.transform.parent = levelContainer;
                levelShopUnitPrefabCopy.Setup(level);
            }
        }
    }
}