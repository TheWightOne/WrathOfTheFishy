using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectionPanel : MonoBehaviour
{
    [SerializeField] private Button bigButton = null;
    [SerializeField] private Button dropButton = null;
    AttackControls ac = null;

    public enum attackType{
        NONE,
        BIG,
        DROP
    }
    void OnEnable(){
        ac = FindObjectOfType<AttackControls>();
        bigButton.interactable = !ac.HasBigAttack;
        dropButton.interactable = !ac.HasDropAttack;
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
    }
}
