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
        agent.navMeshAgent.isStopped = true;
        //death logic here, move from health?
        if(agent.config.DieType == AIAgentConfig.dieType.EVENT){
            agent.myStats.DeathEvent.Invoke();
        }
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
