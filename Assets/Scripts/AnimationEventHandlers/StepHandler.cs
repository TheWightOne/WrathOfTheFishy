using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepHandler : MonoBehaviour
{
    public float destroytime;
    [Header("Unity Setup Variables")]
    [SerializeField]private Transform leftFoot = null;
    [SerializeField]private Transform rightFoot = null;
    [SerializeField]private Transform parentTransform = null;
    [SerializeField]private GameObject stepParticle = null;
    public void FootStepEvent(string foot){
        if(foot.Equals("left")){
            Destroy(Instantiate(stepParticle, leftFoot.position, parentTransform.rotation), destroytime);
        }else{
            Destroy(Instantiate(stepParticle, rightFoot.position, parentTransform.rotation), destroytime);
        }
        //Debug.Log("Footstep " + foot);
    }
}
