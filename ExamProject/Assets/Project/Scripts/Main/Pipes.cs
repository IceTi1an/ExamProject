using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Pipes : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.0f;

        private float leftEdge;


        private void Start()
        {
            leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        }
        private void Update()
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;

            if (transform.position.x < leftEdge)
            {
                Destroy(gameObject);
            }
        }
    }
}
