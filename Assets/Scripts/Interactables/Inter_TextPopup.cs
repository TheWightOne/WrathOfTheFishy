using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Inter_TextPopup : Interactable
{
    private TextMeshProUGUI textDisplay;
    
    [Multiline(8)]
    [SerializeField]private string popupText;

    void Reset(){
        textToDisplay = "Read";
    }
    public override void Action()
    {
        PlayerInteraction playerInteraction = PlayerInteraction.instance;
        playerInteraction.text.text = popupText;
        playerInteraction.textPanel.SetActive(true);

    }

    protected override void OnTriggerExit(Collider other)
    {
        PlayerInteraction playerInteraction = PlayerInteraction.instance;
        playerInteraction.textPanel.SetActive(false);
        base.OnTriggerExit(other);
    }
}
