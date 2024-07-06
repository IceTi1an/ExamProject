using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class BirdShop_Unit : MonoBehaviour
    {
        [SerializeField] private GameObject _selectedState;
        [SerializeField] private GameObject _lockedState;
        [SerializeField] private TextMeshProUGUI _birdName;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Image _birdImage;
    }
}