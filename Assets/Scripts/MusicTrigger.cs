using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;
    private AudioManager audioManager;

    void Start(){
        audioManager = AudioManager.instance;
    }
    void OnTriggerEnter(Collider other){
        if(!other.CompareTag("Player")){
            return;
        }
        
        audioManager.StopPersistentClip("mainTheme");
        audioManager.PlayClip(new AudioSet(clipToPlay, AudioSet.AudioType.MUSIC), "mainTheme");
        enabled = false;
    }
}
