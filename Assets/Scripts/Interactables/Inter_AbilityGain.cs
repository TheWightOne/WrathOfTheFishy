using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_AbilityGain : Interactable
{
    public override void Action()
    {
        PlayerInteraction playerInteraction = PlayerInteraction.instance;
    }

    void Reset(){
        textToDisplay = "Pray";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
