using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIState_ChasePlayer : AIState
{
    [SerializeField]private Transform playerTransform = null;
    public Transform PlayerTransform{
        set{
            playerTransform = value;
        }
    }
    
    float timer = 0.0f;
    public AIStateID GetID()
    {
        return AIStateID.CHASEPLAYER;
    }

    public void Enter(AIAgent agent)
    {
        if(playerTransform == null){
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
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
        agent.navMeshAgent.destination = playerTransform.position;
    }

        if(timer < 0.0f){
            float distance = (playerTransform.position - agent.navMeshAgent.destination).sqrMagnitude;
            if(distance > agent.config.minDistance*agent.config.minDistance){
                if(agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial){
                    agent.navMeshAgent.destination = playerTransform.position;
                }
            }
            timer = agent.config.maxTime;
            
        }
    }
}
