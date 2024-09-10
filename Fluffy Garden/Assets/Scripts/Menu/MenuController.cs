using Store;
using UnityEngine;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        private void Awake()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        public void StartGame()
        {
            LevelDataCarrier.instance.SetLevel(
                SkinsData.GetCurrentCharacter(), 
                SkinsData.GetCurrentBackground());

            LoadingScreenController.instance.ChangeScene(
                "Game", 
                SkinsData.GetCurrentBackground().Sprite);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}

