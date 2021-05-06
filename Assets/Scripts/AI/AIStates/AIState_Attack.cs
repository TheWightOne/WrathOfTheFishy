using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_Attack : AIState
{
    float timer = 0f;
    bool attacking = false;
    public void Enter(AIAgent agent)
    {
        
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AIStateID GetID()
    {
        return AIStateID.ATTACK;
    }

    public void Update(AIAgent agent)
    {
        if((agent.PlayerTransform.position - agent.transform.position).magnitude > agent.config.minDistance * agent.config.minDistance){
            agent.stateMachine.ChangeState(AIStateID.CHASEPLAYER);
        }
        
        if(!attacking){
            timer -= Time.deltaTime;
        }
        if(timer < 0f){
            timer = agent.config.attackTime;
            agent.StartCoroutine(AttackCor(agent));
        }
    }

    IEnumerator AttackCor(AIAgent agent){
        //Debug.Log("Starting Attack!");
        attacking = true;
        agent.combat.WeakAttack();
        yield return new WaitForSeconds(1f);
        attacking = false;
    }
}
