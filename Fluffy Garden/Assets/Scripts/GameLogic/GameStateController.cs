using System;
using PlayerControllers;
using UnityEngine;

namespace GameLogic
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverScreen;
        [SerializeField] AudioSource _gameOverSound;

        public static Action OnShowBestScore;

        private void OnEnable()
        {
            Timer.OnLose += Lose;
            HealthHandler.OnDied += Lose;
        }

        private void OnDisable()
        {
            Timer.OnLose -= Lose;
            HealthHandler.OnDied -= Lose;
        }

        private void Lose()
        {
            _gameOverSound.Play();
            Time.timeScale = 0f;
            _gameOverScreen.SetActive(true);
            OnShowBestScore?.Invoke();
        }
    }
}

