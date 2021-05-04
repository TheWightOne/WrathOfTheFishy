using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIState_ChasePlayer : AIState
{
    
    
    float timer = 0.0f;
    public AIStateID GetID()
    {
        return AIStateID.CHASEPLAYER;
    }

    public void Enter(AIAgent agent)
    {
        
        agent.navMeshAgent.stoppingDistance = agent.config.minDistance;
    }

    public void Exit(AIAgent agent)
    {
        return;
    }

    public void Update(AIAgent agent)
    {
        if(!agent.enabled){
            return;
        }

        timer -= Time.deltaTime;
    if(!agent.navMeshAgent.hasPath){
        agent.navMeshAgent.destination = agent.PlayerTransform.position;
    }

        if(timer < 0.0f){
            float distance = (agent.PlayerTransform.position - agent.navMeshAgent.destination).sqrMagnitude;
            if(distance > agent.config.minDistance*agent.config.minDistance){
                if(agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial){
                    agent.navMeshAgent.destination = agent.PlayerTransform.position;
                }
            }else{
                agent.stateMachine.ChangeState(AIStateID.ATTACK);
            }
            timer = agent.config.maxTime;
            
        }
    }
}
