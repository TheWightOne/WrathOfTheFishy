using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SkyboxCtrlBehaviour : PlayableBehaviour
{
    public Skybox SkyboxMatlReference;

    public override void OnPlayableCreate (Playable playable)
    {
        
    }
}
