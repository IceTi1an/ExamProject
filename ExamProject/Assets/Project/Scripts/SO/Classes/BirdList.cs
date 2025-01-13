using Game;
using Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "BirdContainer", menuName = "SO/Lists/Birds")]
    public partial class BirdList : ScriptableObject, IBirdSaveManager
    {
        public Action<BirdData> onBirdSelected { get; set; }

        public List<BirdData> birdsList = null;
        [SerializeField] private BirdData _currentBird;

        public void Initialize()
        {
            InjectService.Inject(this);
            foreach (BirdData bird in birdsList)
            {
                PlayerPrefs.GetString(bird.name) ;
            }
        }

        public BirdData GetCurrentBird()
        {
            string defaultBirdName = "";
            foreach (BirdData bird in birdsList)
            {
                if (bird.isDefault == true)
                {
                    defaultBirdName = bird.name;
                    break;
                }
            }
            string savedBirdName = PlayerPrefs.GetString("CurrentBird", defaultBirdName);
            foreach (BirdData bird in birdsList)
            {
                if (bird.name == savedBirdName)
                {
                    _currentBird = bird;
                    break;
                }
            }


            return _currentBird;
        }


        public void SetCurrentBird(BirdData bird)
        {
            _currentBird = bird;

            PlayerPrefs.SetString("CurrentBird", bird.name);

            onBirdSelected?.Invoke(_currentBird);
        }
    }
}