using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(1f, 0.2490566f, 0.2490566f)]
[TrackClipType(typeof(SkyboxCtrlClip))]
[TrackBindingType(typeof(Skybox))]
public class SkyboxCtrlTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<SkyboxCtrlMixerBehaviour>.Create (graph, inputCount);
    }
}
