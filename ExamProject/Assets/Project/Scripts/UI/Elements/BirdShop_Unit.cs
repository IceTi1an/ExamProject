using Interfaces;
using SO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static SO.BirdList;

namespace Game.UI
{
    public class BirdShop_Unit : MonoBehaviour
    {
        [SerializeField] private GameObject _selectedState;
        /*[SerializeField] private GameObject _lockedState;*/
        [SerializeField] private TextMeshProUGUI _birdName;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Image _birdIcon;

        private BirdData _birdData;

        [Inject] private IBirdSaveManager _birdSaveManager;

        private bool _isBirdOpen => _birdData.isDefault == true || _birdData.isOpen == true;

        private void Awake()
        {
            InjectService.Inject(this);
        }

        public void Setup(BirdData birdData)
        {
            _selectedState.SetActive(false);
            /*_lockedState.SetActive(false);*/

            _birdData = birdData;

            _birdName.text = _birdData.name;
            _birdIcon.sprite = _birdData.icon;

            /*CheckIsOpen();*/

            CheckSelected(_birdSaveManager.GetCurrentBird());

            /*_birdData.onChanged -= CheckIsOpen;
            _birdData.onChanged += CheckIsOpen;*/
        }

        private void OnEnable()
        {
            _selectButton.onClick.AddListener(Select);
            _birdSaveManager.onBirdSelected += CheckSelected;
        }

        private void OnDisable()
        {
            _selectButton.onClick.RemoveListener(Select);
            _birdSaveManager.onBirdSelected -= CheckSelected;

            /*_birdData.onChanged -= CheckIsOpen;*/
        }
        private void Select()
        {
            if (_isBirdOpen == true)
            {
                _birdSaveManager.SetCurrentBird(_birdData);
            }
            else
            {
                _birdSaveManager.OpenBird(_birdData);
            }
        }

        /*private void CheckIsOpen()
        {
            if (_isBirdOpen == true)
            {
                _lockedState.SetActive(false);
            }
            else
            {
                _lockedState.SetActive(true);
            }
        }*/

        private void CheckSelected(BirdData birdData)
        {
            _selectedState.SetActive(_birdData == birdData);
        }
    }
}