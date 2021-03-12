using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_ChasePlayer : AIState
{
    [SerializeField]private Transform playerTransform = null;
    public Transform PlayerTransform{
        set{
            playerTransform = value;
        }
    }
    [SerializeField] private float maxTime = 1;
    float timer = 0.0f;
    [SerializeField] private float minDistance = 2;
    public AIStateID GetID()
    {
        return AIStateID.CHASEPLAYER;
    }

    public void Enter(AIAgent agent)
    {
        agent.navMeshAgent.stoppingDistance = minDistance;
    }

    public void Exit(AIAgent agent)
    {
        throw new System.NotImplementedException();
    }

    public void Update(AIAgent agent)
    {
        timer -= Time.deltaTime;
        if(timer < 0.0f){
            float distance = (playerTransform.position - agent.navMeshAgent.destination).sqrMagnitude;
            if(distance > minDistance*minDistance){
                agent.navMeshAgent.destination = playerTransform.position;
            }
            timer = maxTime;
            
        }
    }
}
