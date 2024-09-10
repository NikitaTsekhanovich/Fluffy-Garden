using System;
using GameItems;
using Menu;
using UnityEngine;

namespace PlayerMenu
{
    public class PlayerMenuHandler : MonoBehaviour
    {
        [SerializeField] private Transform _saws;
        [SerializeField] private Transform _bonuses;

        public static Action OnRestartTime;
        public static Action OnRestartScore;
        public static Action OnRespawnPlayer;

        public void StopGame()
        {
            Time.timeScale = 0f;
        }

        public void ContinueGame()
        {
            Time.timeScale = 1f;
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;

            OnRestartTime?.Invoke();
            OnRestartScore?.Invoke();
            
            ClearGameObjects();

            if (GameObject.FindWithTag("Player") == null)
                OnRespawnPlayer?.Invoke();
        }

        public void BackToMenu()
        {
            Time.timeScale = 1f;
            ClearGameObjects();
            LoadingScreenController.instance.ChangeScene("Menu", null);
        }

        private void ClearGameObjects()
        {
            foreach (var saw in _saws.GetComponentsInChildren<Saw>())
                Destroy(saw.gameObject);

            foreach (var bonus in _bonuses.GetComponentsInChildren<Bonus>())
                Destroy(bonus.gameObject);            
        }
    }
}

