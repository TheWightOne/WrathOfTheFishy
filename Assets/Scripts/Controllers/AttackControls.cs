using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackControls : MonoBehaviour
{
    private Controls controls;
    [SerializeField]private Animator animator = null;

    bool isAttacking = false;


    


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
        
        controls.General.Attack.performed += _ => {
            StrongAttack();
        };
        controls.General.Attack.canceled += _ =>{
            WeakAttack();
        };
    }

    private void WeakAttack(){
        if(isAttacking){
            return;
        }
        Debug.Log("attacking");
        animator.SetTrigger("Attack");
        //StartCoroutine(MaterialSwapCoroutine(weakMat, 1));
    }

    private void StrongAttack(){
        if(isAttacking){
            return;
        }
        //StartCoroutine(MaterialSwapCoroutine(strongMat, 1));
    }

    

    
}
