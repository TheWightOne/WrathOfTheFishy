using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIAgent : MonoBehaviour
{
    public AIStateMachine stateMachine;
    public AIStateID initialState;
    public NavMeshAgent navMeshAgent;
    public AIAgentConfig config;
    
    void Reset(){
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIState_ChasePlayer());
        stateMachine.ChangeState(initialState);

        navMeshAgent.stoppingDistance = config.minDistance;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
