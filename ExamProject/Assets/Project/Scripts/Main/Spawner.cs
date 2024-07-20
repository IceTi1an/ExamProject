using UnityEngine;

namespace Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _spawnRate = 1.0f;

        [SerializeField] private float _minHeght = -0.5f;

        [SerializeField] private float _maxHeght = 0.2f;

        [SerializeField] private GameObject _pipes;

        private void SpawnPipes()
        {
            
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

    }
}
