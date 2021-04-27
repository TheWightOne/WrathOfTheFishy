using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private AudioClip mainTheme;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        AudioManager.instance.PlayClip(new AudioSet(mainTheme, AudioSet.AudioType.MUSIC), "mainTheme");
    }
}
