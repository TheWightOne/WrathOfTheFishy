using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControls : MonoBehaviour
{
    private Controls controls;

    [SerializeField]private Animator animator;

    private CharacterStats stats;

    void Awake(){
        stats = GetComponent<CharacterStats>();
        controls = new Controls();

        controls.General.Block.started += _ =>{
            animator.SetTrigger("Start_Block");
            animator.SetBool("Block", true);
            stats.perfectTiming = true;
            stats.blocking = true;
        };

        controls.General.Block.performed += _ =>{
            stats.perfectTiming = false;
        };



        controls.General.Block.canceled += _ =>{
            animator.SetBool("Block", false);
            stats.perfectTiming = false;
            stats.blocking = false;

        };
    }

    
    #region - Enable/Disable -
    void OnEnable(){
        controls.Enable();
    }

    void OnDisable(){
        controls.Disable();
    }

    #endregion
}
