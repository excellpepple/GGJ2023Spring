using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("StartGame");
        SceneManager.LoadScene("Level", LoadSceneMode.Additive);
        HideScene("GUITester");
        
    }

    public void ShowControls()
    {
        
    }

    public void OpenCredits()
    {
        
    }

    public void CloseCredits()
    {
        
    }
    
    public void QuitGame()
    {
            
    }
    void HideScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (scene.IsValid() && scene.isLoaded)
        {
            GameObject[] objects = scene.GetRootGameObjects();
            foreach (GameObject obj in objects)
            {
                obj.SetActive(false);
            }
        }
    }
    
}
