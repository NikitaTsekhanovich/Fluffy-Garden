using System;
using UnityEngine;

namespace GameItems
{
    public class Bonus : MonoBehaviour
    {
        private const float BonusTime = 1f;

        public static Action<float> OnTakeBonus;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                OnTakeBonus?.Invoke(BonusTime);
                Destroy(gameObject);
            }
        }
    }
}

