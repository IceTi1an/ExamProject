using Interfaces;
using SO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    public class LevelShop_Unit : MonoBehaviour
    {
        [SerializeField] private GameObject _selectedState;
        [SerializeField] private TextMeshProUGUI _levelName;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Image _levelIcon;

        private LevelData _levelData;

        [Inject] private ILevelSaveManager _levelSaveManager;


        private void Awake()
        {
            InjectService.Inject(this);
        }

        public void Setup(LevelData levelData)
        {
            _selectedState.SetActive(false);

            _levelData = levelData;

            _levelName.text = _levelData.name;
            _levelIcon.sprite = _levelData.icon;

            CheckSelected(_levelSaveManager.GetCurrentLevel());
        }

        private void OnEnable()
        {
            _selectButton.onClick.AddListener(Select);
            _levelSaveManager.onLevelSelected += CheckSelected;
        }

        private void OnDisable()
        {
            _selectButton.onClick.RemoveListener(Select);
            _levelSaveManager.onLevelSelected -= CheckSelected;
        }
        private void Select()
        {
            _levelSaveManager.SetCurrentLevel(_levelData);
        }

        private void CheckSelected(LevelData levelData)
        {
            _selectedState.SetActive(_levelData == levelData);
        }
    }
}