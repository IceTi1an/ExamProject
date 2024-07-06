using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ShopMenu_UI : UIBase
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Transform _contentContainer;
        [SerializeField] private BirdShop_Unit _birdShop_Unit;
    }

}