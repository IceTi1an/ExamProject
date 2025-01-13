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
        [SerializeField] private TextMeshProUGUI _birdName;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Image _birdIcon;

        private BirdData _birdData;

        [Inject] private IBirdSaveManager _birdSaveManager;


        private void Awake()
        {
            InjectService.Inject(this);
        }

        public void Setup(BirdData birdData)
        {
            _selectedState.SetActive(false);

            _birdData = birdData;

            _birdName.text = _birdData.name;
            _birdIcon.sprite = _birdData.icon;


            CheckSelected(_birdSaveManager.GetCurrentBird());

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
        }
        private void Select()
        {
            _birdSaveManager.SetCurrentBird(_birdData);
        }

        private void CheckSelected(BirdData birdData)
        {
            _selectedState.SetActive(_birdData == birdData);
        }
    }
}