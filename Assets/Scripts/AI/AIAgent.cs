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

    private Collider hitbox = null;
    [HideInInspector]
    public CharacterStats myStats;
    [HideInInspector]
    public CharacterCombat combat;

    private Transform playerTransform = null;
    public Transform PlayerTransform{
        get{
            return playerTransform;
        }
        set{
            playerTransform = value;
        }
    }
    
    void Reset(){
        navMeshAgent = GetComponent<NavMeshAgent>();
        myStats = GetComponent<CharacterStats>();
        combat = GetComponent<CharacterCombat>();
    }
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GameObject go;
        if(go = GameObject.FindGameObjectWithTag("Player")){
            PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIState_ChasePlayer());
        stateMachine.RegisterState(new AIState_Death());
        stateMachine.RegisterState(new AIState_Idle());
        stateMachine.RegisterState(new AIState_Attack());
        stateMachine.ChangeState(initialState);
        Debug.Log(initialState);

        navMeshAgent.stoppingDistance = config.minDistance;

        hitbox = GetComponent<Collider>();

        if(!combat){
            combat = GetComponent<CharacterCombat>();
        }

        GetComponent<CharacterStats>().DeathEvent.AddListener(OnDeath);
    }

    void OnDeath(){
        enabled = false;
        if(hitbox){
            hitbox.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void FindPlayer(){
        GameObject player;
        if(player = GameObject.FindGameObjectWithTag("Player")){
            playerTransform = player.transform;
        }
    }
}
