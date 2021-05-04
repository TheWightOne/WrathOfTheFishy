using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Audio;

public class SkipCutsceneControls : MonoBehaviour
{
    private Controls controls;
    private PlayableDirector director;

    public AudioClip musicToSwitchTo;

    void Awake(){
        controls = new Controls();
        controls.General.Attack.performed += _ =>{
            Skip();
        };

        if(!director){
            if(!(director = GetComponent<PlayableDirector>())){
                Debug.LogWarning("No PlayableDirector referenced");
            }
        }
    }

    void OnEnable(){
        controls.Enable();
    }

    void OnDisable(){
        controls.Disable();
    }

    private void Skip(){
        if(director){
            director.time = director.duration - .5f;
            if(musicToSwitchTo){
                AudioManager.instance.PlayClip(new AudioSet(musicToSwitchTo, AudioSet.AudioType.MUSIC), "mainTheme");
            }
        }
    }
}
