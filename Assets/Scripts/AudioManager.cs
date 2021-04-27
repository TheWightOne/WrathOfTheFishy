using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    //a list of audio sources to pool from
    //these sources are called for various SFX. hit, swing, die, etc.
    //they are the ones that will NOT loop and can be overwritten if need be
    private List<AudioSource> sourcePool = new List<AudioSource>();

    //a List of persistent sources
    //these will play music or other audio clips that must remain constant throughout the game
    private List<PersistentSource> persistentSources = new List<PersistentSource>();
    [SerializeField]private int defaultSourceCount = 1;

    [Header("Volume settings")]
    [Range(0,1)]
    [SerializeField] private float masterVolume = 1f;
    [SerializeField] private float SFXVolume = 1f;
    [SerializeField] private float musicVolume = 1f;
    [SerializeField] private float voiceVolume = 1f;

    void Awake(){
        if(!instance){
            instance = this;
        }else{
            Debug.Log("AudioManager Singleton Violation at " + gameObject.name);
            Destroy(this);
            return;
        }
    }

    void Start()
    {
        for(int i = 0; i < defaultSourceCount; i++){
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.playOnAwake = false;
            sourcePool.Add(newSource);
        }
    }

    public void PlayClip(AudioSet set, string persistentName){
        if(sourcePool.Count == 0){
            sourcePool.Add(gameObject.AddComponent<AudioSource>());
        }
        AudioSource sourceToUse = sourcePool[0];
        sourceToUse.clip = set.clip;
        sourcePool.Remove(sourceToUse);

        if(persistentName.Equals("")){
            Debug.Log("Adding to main pool");
            sourcePool.Add(sourceToUse);
        }else{
            Debug.Log("Adding to persistent list");

            sourceToUse.loop = true;
            persistentSources.Add(new PersistentSource(persistentName, sourceToUse));
        }
        sourceToUse.Play();
    }

    public void PlayClip(AudioSet set){
        PlayClip(set, "");
    }

    //stops a persistent source of a given name. 
    //returns true if the source was found and stopped, returns false if the source was not found
    public bool StopPersistentClip(string persistentName){
        foreach(PersistentSource ps in persistentSources){
            if(ps.name == persistentName){
                ps.source.Stop();
                ps.source.loop = false;
                persistentSources.Remove(ps);
                sourcePool.Add(ps.source);
                return true;
            }
        }
        return false;
    }

    private class PersistentSource{
        public string name;
        public AudioSource source;

        public PersistentSource(string _name, AudioSource _source)
        {
            name = _name;
            source = _source;
        }
    }
}

[System.Serializable]
public class AudioSet{
    public enum AudioType{
        MUSIC,
        SFX,
        VOICE
    }

    public AudioClip clip;
    public AudioType type;

    public AudioSet(AudioClip _clip, AudioType _type)
    {
        clip = _clip;
        type = _type;
    }
}
