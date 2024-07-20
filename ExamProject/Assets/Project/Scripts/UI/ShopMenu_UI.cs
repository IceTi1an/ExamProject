using SO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    public class ShopMenu_UI : UIBase
    {
        public Button exitButton;
        public Transform contentContainer;
        public BirdShop_Unit birdShop_Unit;

        [Inject] private BirdList birdList;

        private void Awake()
        {
            InjectService.Inject(this);

            ClearBirds();
            SpawnBirds();
        }

        /*public CarData GetCurrentCar()
        {
            string carName = PlayerPrefs
        }*/

        private void ClearBirds()
        {

            foreach (var bird in contentContainer.GetComponentsInChildren<BirdShop_Unit>(true))
            {
                Destroy(bird.gameObject);
            }
        }

        private void SpawnBirds()
        {
            foreach (var bird in birdList.birdsList)
            {
                var birdShopUnitPrefabCopy = Instantiate(birdShop_Unit, contentContainer);
                birdShopUnitPrefabCopy.transform.parent = contentContainer;
                birdShopUnitPrefabCopy.Setup(bird);
            }
        }
    }
}