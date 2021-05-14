using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//this script is in charge of translating the player's input into commands for the character
//
[RequireComponent(typeof(CharacterCombat))]
public class AttackControls : MonoBehaviour
{
    private Controls controls;
    
    [Header("Unity Setup Values")]
    
    bool isAttacking = false;

    //this bool tracks when the player's
    //input has been used to perform their attack
    //this prevents multiple attacks with a single click
    bool attackedWithInput = false;
    
    private CharacterCombat characterCombat = null;

    private bool hasDropAttack = false;
    private bool hasBigAttack = false;

    public bool HasDropAttack { 
        get => hasDropAttack;
        set{
            hasDropAttack = value;
            GetComponentInChildren<Animator>().SetBool("DropAttackEnabled", value);
        } 
    }
    public bool HasBigAttack { 
        get => hasBigAttack;
        set{
            hasBigAttack = value;
            GetComponentInChildren<Animator>().SetBool("BigAttackEnabled", value);
        } 
    }

    #region - Enable/Disable -  
    void OnEnable(){
        controls.Enable();
    }

    void OnDisable(){
        controls.Disable();
    }

    #endregion

    void Reset(){
        characterCombat = GetComponent<CharacterCombat>();
    }

    void Awake(){
        if(!characterCombat){
            characterCombat = GetComponent<CharacterCombat>();
        }
        controls = new Controls();
        controls.General.HeavyAttack.started += _ =>{
            attackedWithInput = false;
            Debug.Log("StrongAttack");
            //return;
            if(isAttacking || attackedWithInput){
                return;
            }
            
            //Debug.Log("heavy attack");
            characterCombat.StrongAttack();
            attackedWithInput = true;
        };
        controls.General.HeavyAttack.performed += _ => {

        };
        controls.General.Attack.started += _ => {
            attackedWithInput = false;
        };
        controls.General.Attack.performed += _ =>{
            Debug.Log("WeakAttack");

            //return;
            if(isAttacking || attackedWithInput){
                return;
            }
            //Debug.Log("normal attack");
            characterCombat.WeakAttack();
            attackedWithInput = true;

        };
        
    }

    /*
    private void WeakAttack(){
        Debug.Log("weak attack");

        animator.SetInteger("lite_attack_count", liteAttackCount);

        Collider[] hitEnemies = Physics.OverlapBox(attackPoint.position, new Vector3(attackRange.x, attackRange.y, attackRange.z), gameObject.transform.rotation, enemyLayers);

        foreach(Collider enemy in hitEnemies){
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<AIHealth>().TakeDamage(attackDamage);
            Destroy(Instantiate(hitParticles, new Vector3(enemy.gameObject.transform.position.x, attackPoint.position.y, enemy.gameObject.transform.position.z), new Quaternion()), 1.5f);

        }
    }

    */

    

    
}
