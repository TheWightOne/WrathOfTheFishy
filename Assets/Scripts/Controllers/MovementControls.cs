using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{
    private Controls controls;
    private Vector2 movementInput;

    [SerializeField]private CharacterController characterController;
    [SerializeField]private float speed = 6f;
    
    // Start is called before the first frame update
    void Awake()
    {
        controls = new Controls();
        controls.General.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }

    #region - Enable/Disable -
    void OnEnable(){
        controls.Enable();
    }

    void OnDisable(){
        controls.Disable();
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(movementInput.x, 0, movementInput.y);
        characterController.Move(moveVector*speed*Time.deltaTime);
    }
}
