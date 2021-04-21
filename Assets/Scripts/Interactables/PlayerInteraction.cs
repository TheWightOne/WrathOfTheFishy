using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//handles the player's interaction controls
public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;
    private Interactable interactable = null;

    [Header("UI Elements")]

    public GameObject textPanel = null;
    
    [HideInInspector]public TextMeshProUGUI text = null;

    public AbilitySelectionPanel abilitySelectionPanel = null;



    public Interactable Interactable{
        get{
            return interactable;
        }
        set{
            interactable = value;
        }
    }

    private Controls controls;
    void Awake(){
        if(!instance){
            instance = this;
        }else{
            Destroy(this);
        }

        controls  = new Controls();

        controls.General.Interact.performed += _ =>{
            if(interactable){
                interactable.Action();
            }
        };
        if(textPanel){
            text = textPanel.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    void Validate(){
        if(textPanel){
            text = textPanel.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    #region - Enable/Disable -
    void OnEnable(){
        controls.Enable();
    }

    void OnDisable(){
        controls.Disable();
    }

    #endregion
    


}
