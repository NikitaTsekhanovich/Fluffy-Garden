using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

namespace Menu 
{
    public class LoadingScreenController : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private TMP_Text _loadingText;
        private Sprite _currentBackground;

        public static LoadingScreenController instance;

        private void Start() 
        {             
            if (instance == null) 
            { 
                instance = this; 
                DontDestroyOnLoad(gameObject);
            } 
            else 
            { 
                Destroy(this);  
            } 
        }
        
        public void ChangeScene(string nameScene, Sprite currentBackground)
        {
            if (currentBackground != null)
                _currentBackground = currentBackground;
           StartAnimationFade(nameScene);
        }

        private void StartAnimationFade(string nameScene)
        {
            _loadingText.DOFade(1f, 1f);
            _background.sprite = _currentBackground;

            DOTween.Sequence()
                .Append(_background.DOFade(1f, 1f))
                .OnComplete(() => LoadScene(nameScene));
        }

        private void LoadScene(string nameScene)
        {
            SceneManager.LoadScene(nameScene);
            EndAnimationFade();
            Time.timeScale = 1f;
        }

        private void EndAnimationFade()
        {
            _loadingText.DOFade(0f, 1f);
            _background.DOFade(0f, 1f);
        }
    }
}

