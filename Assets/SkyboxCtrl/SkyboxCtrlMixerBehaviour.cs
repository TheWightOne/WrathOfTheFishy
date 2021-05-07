using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SkyboxCtrlMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Skybox trackBinding = playerData as Skybox;

        if (!trackBinding)
            return;

        int inputCount = playable.GetInputCount ();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<SkyboxCtrlBehaviour> inputPlayable = (ScriptPlayable<SkyboxCtrlBehaviour>)playable.GetInput(i);
            SkyboxCtrlBehaviour input = inputPlayable.GetBehaviour ();
            
            // Use the above variables to process each frame of this playable.
            
        }
    }
}
