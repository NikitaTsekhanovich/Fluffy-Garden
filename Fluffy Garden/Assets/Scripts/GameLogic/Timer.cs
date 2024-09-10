using System;
using System.Collections;
using GameItems;
using PlayerMenu;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private Image _progressBarTime;
        [SerializeField] private TMP_Text _currentTimeText;
        private const float UpperLimitTime = 60f;
        private const float LowerLimitTime = 0f;
        private float currentTime = UpperLimitTime;

        public static Action OnLose;

        private void OnEnable()
        {
            Bonus.OnTakeBonus += TakeBonusTime;
            PlayerMenuHandler.OnRestartTime += RestartTime;
        }

        private void OnDisable()
        {
            Bonus.OnTakeBonus -= TakeBonusTime;
            PlayerMenuHandler.OnRestartTime -= RestartTime;
        }

        private void Start()
        {
            StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {
            while (true)
            {
                currentTime -= 0.1f;

                if (currentTime >= UpperLimitTime)
                    currentTime = 60f;
                if (currentTime <= LowerLimitTime)
                    OnLose?.Invoke();

                _progressBarTime.fillAmount = currentTime / UpperLimitTime;
                _currentTimeText.text = $"{Math.Round(currentTime)} s";

                yield return new WaitForSeconds(0.1f);
            }
        }

        private void RestartTime()
        {
            currentTime = UpperLimitTime;
        }

        private void TakeBonusTime(float bonusTime)
        {
            currentTime += bonusTime;
        }
    }
}

