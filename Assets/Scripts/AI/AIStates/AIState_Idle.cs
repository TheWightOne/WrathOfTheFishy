using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_Idle : AIState
{
    AIAgent agent1;
    public AIStateID GetID()
    {
        return AIStateID.IDLE;
    }
    public void Enter(AIAgent agent)
    {
        agent1 = agent;
        agent1.myStats.TakeDamageEvent.AddListener(OnTakeDamage);
    }

    public void Exit(AIAgent agent)
    {
        agent1.myStats.TakeDamageEvent.RemoveListener(OnTakeDamage);
    }

    public void Update(AIAgent agent)
    {
        if(!agent.PlayerTransform){
            GameObject player;
            if(!(player = GameObject.FindGameObjectWithTag("Player"))){
                return;
            }
            agent.PlayerTransform = player.transform;
            return;
        }
        Vector3 playerDirection = agent.PlayerTransform.position - agent.transform.position;
        if(playerDirection.magnitude > agent.config.maxSightDistance){
            return;
        }

        Vector3 agentDirection = agent.transform.forward;

        playerDirection.Normalize();

        float dotProduct = Vector3.Dot(playerDirection, agentDirection);
        if(dotProduct > 0.0){
            //Debug.Log("Switching to chase because we spotted the player " + dotProduct);
            agent.stateMachine.ChangeState(AIStateID.CHASEPLAYER);
        }
    }

    private void OnTakeDamage(){
        //Debug.Log("Changing to chase player state because we took damage");
        agent1.stateMachine.ChangeState(AIStateID.CHASEPLAYER);
    }

}
