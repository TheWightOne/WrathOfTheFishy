﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneUtilities : MonoBehaviour
{
    AudioManager audioManager = null;
    
    void Start(){
        audioManager = AudioManager.instance;
    }

    public void SetMusic(AudioClip clipToPlay){
        audioManager.StopPersistentClip("mainTheme");

        audioManager.PlayClip(new AudioSet(clipToPlay, AudioSet.AudioType.MUSIC), "mainTheme");
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
