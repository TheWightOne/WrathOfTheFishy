using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectionPanel : MonoBehaviour
{
    [SerializeField] private Button bigButton = null;
    [SerializeField] private Button dropButton = null;
    [SerializeField] private Button lightningButton = null;
    AttackControls ac = null;

    public enum attackType{
        NONE,
        BIG,
        DROP,
        LIGHTNING
    }
    void OnEnable(){
        ac = FindObjectOfType<AttackControls>();
        bigButton.interactable = !ac.HasBigAttack;
        dropButton.interactable = !ac.HasDropAttack;
        lightningButton.interactable = !ac.HasLightningAttack;
    }


    public void EnableAttack(int attackToEnable){
        if(attackToEnable == (int)attackType.NONE){
            return;
        }

        if(attackToEnable == (int)attackType.BIG){
            ac.HasBigAttack = true;
        }
        if(attackToEnable == (int)attackType.DROP){
            ac.HasDropAttack = true;
        }
        if(attackToEnable == (int)attackType.LIGHTNING){
            ac.HasLightningAttack = true;
        }
    }
}
