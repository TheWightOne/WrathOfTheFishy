using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadZoneTrigger : MonoBehaviour
{
    [SerializeField]private string sceneName;
    void OnTriggerEnter(Collider other){
        if(!other.CompareTag("Player")){
            return;
        }
        SceneManager.LoadScene(sceneName);
    }
}
