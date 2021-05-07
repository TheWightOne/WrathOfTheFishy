using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SkyboxCtrlClip : PlayableAsset, ITimelineClipAsset
{
    public SkyboxCtrlBehaviour template = new SkyboxCtrlBehaviour ();
    public ExposedReference<Skybox> SkyboxMatlReference;

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Extrapolation | ClipCaps.ClipIn; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SkyboxCtrlBehaviour>.Create (graph, template);
        SkyboxCtrlBehaviour clone = playable.GetBehaviour ();
        clone.SkyboxMatlReference = SkyboxMatlReference.Resolve (graph.GetResolver ());
        return playable;
    }
}
