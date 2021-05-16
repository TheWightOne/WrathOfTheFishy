using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUtilities : MonoBehaviour
{
    
    
    //toggles the gameObject this is attached to.
    public void ToggleActive(){
        gameObject.SetActive(!gameObject.activeSelf);
    }

    //loads a scene
    public void LoadScene(string SceneName){
        //gameObject.SetActive(false);
        Debug.Log("load flag 1");
        SceneManager.LoadScene(SceneName);
        
    }

    public void LoadScene(int buildIndex){
        string sceneName = SceneManager.GetSceneByBuildIndex(buildIndex).name;

        LoadScene(sceneName);
    }

    
}
