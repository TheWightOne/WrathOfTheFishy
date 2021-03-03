using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackControls : MonoBehaviour
{
    private Controls controls;


    [SerializeField]private float attackDamage = 5;
    
    

    [Header("Unity Setup Values")]
    [SerializeField]private Animator animator = null;
    [SerializeField]private Transform attackPoint = null;
    [SerializeField]private float attackRangeX = 0.5f;
    [SerializeField]private float attackRangeY = 0.5f;
    [SerializeField]private float attackRangeZ = 0.5f;
    [SerializeField]private LayerMask enemyLayers = 0;
    [SerializeField]private GameObject hitParticles = null;

    bool isAttacking = false;
    bool attackedWithInput = false;
    private int liteAttackCount = 0;


    #region - Enable/Disable -  
    void OnEnable(){
        controls.Enable();
    }

    void OnDisable(){
        controls.Disable();
    }

    #endregion

    void Awake(){
        controls = new Controls();
        controls.General.Attack.started += _ => {
            attackedWithInput = false;
        };
        controls.General.Attack.performed += _ => {
            StrongAttack();
            attackedWithInput = true;
        };
        controls.General.Attack.canceled += _ =>{
            WeakAttack();
            attackedWithInput = true;
        };
    }

    private void WeakAttack(){
        if(isAttacking || attackedWithInput){
            return;
        }
        Debug.Log("weak attack");
        animator.SetTrigger("Attack");

        liteAttackCount ++;
        animator.SetInteger("lite_attack_count", liteAttackCount);

        Collider[] hitEnemies = Physics.OverlapBox(attackPoint.position, new Vector3(attackRangeX, attackRangeY, attackRangeZ), gameObject.transform.rotation, enemyLayers);

        foreach(Collider enemy in hitEnemies){
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<AIHealth>().TakeDamage(attackDamage);
            Destroy(Instantiate(hitParticles, new Vector3(enemy.gameObject.transform.position.x, attackPoint.position.y, enemy.gameObject.transform.position.z), new Quaternion()), 1.5f);

        }
    }

    private void StrongAttack(){
        if(isAttacking || attackedWithInput){
            return;
        }
        Debug.Log("strong attack");
        liteAttackCount = 0;
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.matrix = attackPoint.transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(attackRangeX/2, attackRangeY/2, attackRangeZ/2));
    }

    
}
