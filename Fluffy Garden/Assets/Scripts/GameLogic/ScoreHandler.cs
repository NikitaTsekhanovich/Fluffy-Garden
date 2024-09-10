using GameItems;
using PlayerControllers;
using PlayerMenu;
using TMPro;
using UnityEngine;

namespace GameLogic
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] TMP_Text _scoreText;
        [SerializeField] TMP_Text _bestScoreText;
        private int _currentScore;

        private void OnEnable()
        {
            Saw.OnIncreaseScore += IncreaseScore;
            PlayerMenuHandler.OnRestartScore += RestartScore;
            GameStateController.OnShowBestScore += ShowBestScore;
        }

        private void OnDisable()
        {
            Saw.OnIncreaseScore -= IncreaseScore;
            PlayerMenuHandler.OnRestartScore -= RestartScore;
            GameStateController.OnShowBestScore -= ShowBestScore;
        }

        private void IncreaseScore()
        {
            _currentScore++;
            _scoreText.text = $"Score: {_currentScore}";
            PlayerDataController.ChangeBestScore(_currentScore);
            PlayerDataController.ChangeCountCoin(_currentScore);
        }

        private void RestartScore()
        {
            _currentScore = 0;
            _scoreText.text = $"Score: {_currentScore}";
        }

        public void ShowBestScore()
        {
            _bestScoreText.text = $"Best score: {PlayerControllers.PlayerDataController.BestScore}";
        }
    }
}

