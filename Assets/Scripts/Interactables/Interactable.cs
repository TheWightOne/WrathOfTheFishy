using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interactable : MonoBehaviour, IInteractable
{
    abstract public void Action();

    //the player interaction controller on the player
    private PlayerInteraction interaction;

    [Tooltip("The Text displayed over the player's head when they can interact with the object")]
    //the text to be displayed by the text prompt when the player enters the interaction zone
    [SerializeField] protected string textToDisplay;
    public string TextToDisplay{
        get{
            return textToDisplay;
        }
    }
    protected virtual void OnTriggerEnter(Collider other){
        //Debug.Log("Hitbox Entered!");
        if(!(other.gameObject.tag == "Player")){
            return;
        }

        if(interaction = other.GetComponent<PlayerInteraction>()){
            interaction.Interactable = this;
        }
    }

    protected virtual void OnTriggerExit(Collider other){
        if(!(other.gameObject.tag == "Player")){
            return;
        }

        if((interaction = other.GetComponent<PlayerInteraction>()) && (Object)interaction.Interactable == this){
            interaction.Interactable = null;
        }
    }
}
