using TMPro;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        /*[SerializeField] private BirdMoveMent _bird;*/

        [SerializeField] private TextMeshProUGUI _scoreText;

        [SerializeField] private GameObject _playButton;

        [SerializeField] private GameObject _gameOver;

        private int score;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            /*Instantiate(_bird);*/

            Pause();
        }

        public void Play()
        {
            score = 0;
            _scoreText.text = score.ToString();

            _gameOver.SetActive(false);
            _playButton.SetActive(false);

            Time.timeScale = 1f;
            /*_bird.enabled = true;*/

            Pipes[] pipes = FindObjectsOfType<Pipes>();

            for (int i = 0; i < pipes.Length;i++)
            {
                Destroy(pipes[i].gameObject);
            }

        }

        public void Pause()
        {
            Time.timeScale = 0;
            /*_bird.enabled = false;*/
        }
        public void GameOver()
        {
            _gameOver.SetActive(true);
            _playButton.SetActive(true);

            Pause();
        }
        public void IncreaseScore()
        {
            score++;
            _scoreText.text = score.ToString();
        }
    }
}
