using UnityEngine;

namespace PlayerControllers
{
    public class PlayerDataController
    {
        public static int Coins => PlayerPrefs.GetInt("Coins");
        public static int BestScore => PlayerPrefs.GetInt("BestScore");

        public static void ChangeBestScore(int currentScore)
        {
            if (BestScore < currentScore)
                PlayerPrefs.SetInt("BestScore", currentScore);
        }

        public static void ChangeCountCoin(int countCoin)
        {
            var currentCoin = PlayerPrefs.GetInt("Coins");
            PlayerPrefs.SetInt("Coins", currentCoin + countCoin);
        }

        public static bool CanBuyItem(int price)
        {
            var currentCoin = PlayerPrefs.GetInt("Coins");

            if (currentCoin - price >= 0)
                return true;
            return false;
        }
    }
}

