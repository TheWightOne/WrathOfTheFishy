using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_AbilityGain : Interactable
{
    public override void Action()
    {
        PlayerInteraction playerInteraction = PlayerInteraction.instance;
        if(playerInteraction && playerInteraction.abilitySelectionPanel){
            playerInteraction.abilitySelectionPanel.SetActive(true);
            MouseController.instance.EnableMouse();
        }
    }

    void Reset(){
        textToDisplay = "Pray";
    }

    protected override void OnTriggerExit(Collider other)
    {
        PlayerInteraction playerInteraction = PlayerInteraction.instance;
        if(playerInteraction && playerInteraction.abilitySelectionPanel){
            playerInteraction.abilitySelectionPanel.SetActive(false);
        }
        MouseController.instance.DisableMouse();
        base.OnTriggerExit(other);
    }
}
