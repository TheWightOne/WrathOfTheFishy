using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inter_StaticEvent : Interactable
{
    [SerializeField]private UnityEvent eventToTrigger;

    void Reset(){
        textToDisplay = "Talk";
    }
    
    

    override public void Action(){
        eventToTrigger.Invoke();
    }
}
