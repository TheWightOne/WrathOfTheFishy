using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackControls : MonoBehaviour
{
    private Controls controls;

    bool isAttacking = false;


    [Header("Debugging")]
    private Material defaultMaterial;
    [SerializeField] private Material weakMat = null;
    [SerializeField]private Material strongMat = null;
    [SerializeField]private MeshRenderer meshRenderer = null;


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
        StartCoroutine(MaterialSwapCoroutine(weakMat, 1));
    }

    private void StrongAttack(){
        if(isAttacking){
            return;
        }
        StartCoroutine(MaterialSwapCoroutine(strongMat, 1));
    }

    private IEnumerator MaterialSwapCoroutine(Material material, float seconds){
        isAttacking = true;
        meshRenderer.material = material;
        yield return new WaitForSeconds(seconds);
        meshRenderer.material = defaultMaterial;
        isAttacking = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        defaultMaterial = meshRenderer.material;
    }

    
}
