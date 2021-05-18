using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerHandler : MonoBehaviour
{
    private CharacterCombat combat;

    void Start(){
        combat = GetComponentInParent<CharacterCombat>();
    }
    public void DetectHit(int hitboxIndex){
        combat.ActivateHitbox(hitboxIndex);
    }

    public void StopDetectingHit(int hitboxIndex){
        combat.DeactivateHitbox(hitboxIndex);
    }

    public void ResetCount(){
        combat.ResetCount();
    }

    public void CallLightning(){
        Debug.Log("calling lightning");
        combat.LightningAttack();
    }

    public void DoBoom(){
        combat.DoBoom();
    }
}
