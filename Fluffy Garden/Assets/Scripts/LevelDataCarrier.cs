using Store.Items;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDataCarrier : MonoBehaviour
{
    private CharacterData _characterData;
    private BackgroundsData _backgroundsData;
    public static LevelDataCarrier instance;

    private void Awake() 
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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    public void SetLevel(CharacterData characterData, BackgroundsData backgroundsData)
    {
        _characterData = characterData;
        _backgroundsData = backgroundsData;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "Game")
        {
            var gameLoader = GameObject.FindWithTag("GameDataLoader").GetComponent<GameDataLoader>();
            gameLoader.SetGameData(_characterData, _backgroundsData);
        }
        // if (scene.name == "Menu" && LoadingScreenController.instance != null)
        // {
        //     LoadingScreenController.instance.EndAnimationFade();
        // }
    }
}
