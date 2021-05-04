using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_Idle : AIState
{
    public AIStateID GetID()
    {
        return AIStateID.IDLE;
    }
    public void Enter(AIAgent agent)
    {
    }

    public void Exit(AIAgent agent)
    {
    }

    public void Update(AIAgent agent)
    {
        Vector3 playerDirection = agent.PlayerTransform.position - agent.transform.position;
        if(playerDirection.magnitude > agent.config.maxSightDistance){
            return;
        }

        Vector3 agentDirection = agent.transform.forward;

        playerDirection.Normalize();

        float dotProduct = Vector3.Dot(playerDirection, agentDirection);
        if(dotProduct > 0.0){
            agent.stateMachine.ChangeState(AIStateID.CHASEPLAYER);
        }
    }

}
