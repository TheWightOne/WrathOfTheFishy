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
    [SerializeField]private Vector3 attackRange = new Vector3(1,1,1);
    [SerializeField]private Transform attackPoint = null;
    [SerializeField]private LayerMask enemyLayers = 0;

    [Header("Prefabs")]
    [SerializeField]private GameObject hitParticles = null;

    private int liteAttackCount = 0;
    
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

    void Attack(CharacterStats targetStats){
        targetStats.CurrentHealth -= myStats.Attack;
    }

    public void WeakAttack(){
        Debug.Log("weak attack");
        animator.SetTrigger("Attack");

        liteAttackCount ++;
        animator.SetInteger("lite_attack_count", liteAttackCount);

        Collider[] hitTargets = Physics.OverlapBox(attackPoint.position, new Vector3(attackRange.x, attackRange.y, attackRange.z), gameObject.transform.rotation, enemyLayers);

        foreach(Collider target in hitTargets){
            Debug.Log("We hit " + target.name);
            target.GetComponent<CharacterStats>().CurrentHealth -= myStats.Attack;
            Destroy(Instantiate(hitParticles, new Vector3(target.gameObject.transform.position.x, attackPoint.position.y, target.gameObject.transform.position.z), new Quaternion()), 1.5f);
        }
    }

    public void StrongAttack(){
        
        Debug.Log("strong attack");
        liteAttackCount = 0;
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.matrix = attackPoint.transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(attackRange.x/2, attackRange.y/2, attackRange.z/2));
    }
}
