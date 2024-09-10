using UnityEngine;

public class SaverGameobjects : MonoBehaviour
{
    private void Start() 
    {         
        if (GameObject.FindGameObjectsWithTag("BackgroundMusic").Length <= 1) 
            DontDestroyOnLoad(gameObject);
        else 
            Destroy(gameObject);  
    }
}
