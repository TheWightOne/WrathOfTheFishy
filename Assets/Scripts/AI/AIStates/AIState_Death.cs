using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_Death : AIState
{
    public AIStateID GetID(){
        return AIStateID.DEATH;
    }
    public void Enter(AIAgent agent)
    {
        //death logic here, move from health?
        
    }

    
    public void Exit(AIAgent agent)
    {
        throw new System.NotImplementedException();
    }


    public void Update(AIAgent agent)
    {
        return;
    }

}
