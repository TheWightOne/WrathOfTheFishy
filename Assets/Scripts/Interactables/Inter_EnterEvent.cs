using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inter_EnterEvent : Interactable
{
    public UnityEvent EnterEvents = null;
    public UnityEvent ExitEvents = null;
    
    public override void Action()
    {
        return;
    }

    protected override void OnTriggerEnter(Collider other){
        Debug.Log("action triggered!");
        EnterEvents.Invoke();
    }

    protected override void OnTriggerExit(Collider other){
        Debug.Log("action triggered!");
        ExitEvents.Invoke();
    }
}
