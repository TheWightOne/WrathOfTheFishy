using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AILocomotion : MonoBehaviour
{
    [SerializeField]private Transform playerTransform = null;
    public Transform PlayerTransform{
        set{
            playerTransform = value;
        }
    }
    private NavMeshAgent agent;
    private Animator animator;

    [SerializeField] private float maxTime = 1;
    float timer = 0.0f;
    [SerializeField] private float minDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0.0f){
            float distance = (playerTransform.position - agent.destination).sqrMagnitude;
            if(distance > minDistance*minDistance){
                agent.destination = playerTransform.position;
            }
            timer = maxTime;
            
        }
        
        animator.SetFloat("Speed",agent.velocity.magnitude);
    }
}
