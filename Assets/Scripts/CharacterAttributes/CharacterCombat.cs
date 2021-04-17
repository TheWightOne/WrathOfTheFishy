using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script contains the logic of handling player/enemy attack interactions
[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    private CharacterStats myStats;

    [Header("Unity Setup Variables")]
    [SerializeField]private Animator animator = null;
    //[SerializeField]private Vector3 attackRange = new Vector3(1,1,1);
    //[SerializeField]private Transform attackPoint = null;
    [SerializeField]private LayerMask enemyLayers = 0;

    [Header("Prefabs")]
    [SerializeField]private GameObject hitParticles = null;

    private int liteAttackCount = 0;
    private float timeSinceLastAttack = 0f;
    private float timeToAttackReset;

    void Reset(){
        myStats = GetComponent<CharacterStats>();
        animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(!myStats){
            myStats = GetComponent<CharacterStats>();
        }
        
    }

    void Update(){
        timeSinceLastAttack += Time.deltaTime;
        if(timeSinceLastAttack > timeToAttackReset){
            liteAttackCount = 0;
        }
    }

    void Attack(CharacterStats targetStats){
        targetStats.CurrentHealth -= myStats.Attack;
    }

    public void WeakAttack(){
        //Debug.Log("weak attack");
        animator.SetTrigger("Attack");

        liteAttackCount ++;
        animator.SetInteger("lite_attack_count", liteAttackCount);

        timeSinceLastAttack = 0f;
    }

    public void StrongAttack(){
        
        Debug.Log("strong attack");
        animator.SetTrigger("Heavy_Attack");
    }
/*
    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.matrix = attackPoint.transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(attackRange.x/2, attackRange.y/2, attackRange.z/2));
    }
*/

    //the list of hitboxes the character can use. Animators should be familiar with how to allocate these
    [SerializeField]private List<Hitbox> hitboxes;

    public void ActivateHitbox(int hitboxIndex){
        hitboxes[hitboxIndex].enabled = true;
        hitboxes[hitboxIndex].hitDetectedEvent.AddListener(DealDamage);
    }

    public void DeactivateHitbox(int hitboxIndex){
        hitboxes[hitboxIndex].enabled = false;
    }

    public void DealDamage(){
        foreach(Hitbox h in hitboxes){
            if(h.enabled){
                foreach(CharacterStats ch in h.TargetStats){
                    ch.CurrentHealth -= myStats.Attack;
                }
                h.SetStatsAsHit(h.TargetStats);
                Destroy(Instantiate(hitParticles, new Vector3(h.gameObject.transform.position.x, h.transform.position.y + 1, h.transform.gameObject.transform.position.z), new Quaternion()), 1.5f);
            }
        }
    }
}
