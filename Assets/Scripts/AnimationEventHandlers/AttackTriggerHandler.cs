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
}
