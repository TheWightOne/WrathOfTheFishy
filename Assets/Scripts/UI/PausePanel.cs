using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private Controls controls;

    [SerializeField] private GameObject pausePanel;

    void Awake(){
        controls = new Controls();

        controls.General.Pause.performed += _ =>{
            TogglePause();
        };
        controls.Enable();
    }



    void OnDestroy(){
        controls.Disable();
    }
    public void TogglePause(){
        pausePanel.SetActive(!pausePanel.activeSelf);
        if(pausePanel.activeSelf){
            MouseController.instance.enabled = false;
            Time.timeScale = 0;
            
        }else{
            MouseController.instance.enabled = true;
            Time.timeScale = 1;
        }
    }

}
