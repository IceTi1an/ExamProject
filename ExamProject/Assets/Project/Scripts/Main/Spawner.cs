using UnityEngine;
using System;


namespace Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _spawnRate = 1.0f;

        [SerializeField] private float _minHeight = -0.5f;

        [SerializeField] private float _maxHeight = 0.2f;

        [SerializeField] private Pipes _pipes;

        private void OnEnable()
        {
            InvokeRepeating(nameof(Spawn), _spawnRate, _spawnRate);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(Spawn));
        }

        private void Spawn()
        {
            Pipes pipes = Instantiate(_pipes, transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * UnityEngine.Random.Range(_minHeight, _maxHeight);
        }

    }
}
