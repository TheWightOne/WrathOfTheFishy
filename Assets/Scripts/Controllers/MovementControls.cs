using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{
    private Controls controls;
    private Vector2 movementInput;

    [SerializeField]private CharacterController characterController = null;
    [SerializeField]private Transform cam = null;
    [SerializeField]private float speed = 6f;
    [SerializeField]private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    [SerializeField]private float gravity = -9.81f;
    [SerializeField]private Transform groundCheck = null;
    [SerializeField]private float groundDistance = 0f;
    [SerializeField]private LayerMask groundMask;
    private bool isGrounded= false;
    private Vector3 velocity = new Vector3(0, 0, 0);

    [Header("Debugging")]
    [SerializeField]private Material grounded;
    [SerializeField]private Material air;
    [SerializeField]private MeshRenderer meshRenderer;


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
    void FixedUpdate()
    {
        //checks if the player is grounded. if so, reset fall velocity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            meshRenderer.material = grounded;
            velocity.y = -.2f * Time.deltaTime * Time.deltaTime;
        }else{
            meshRenderer.material = air;
            velocity.y += gravity * Time.deltaTime * Time.deltaTime;
        }



        characterController.Move(velocity);

        //input by the player
        Vector3 moveVector = new Vector3(movementInput.x, 0, movementInput.y);

        if(moveVector.sqrMagnitude <= 0.1f){
            return;
        }
      
        
        float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;        

        characterController.Move(moveDir.normalized * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime * Time.deltaTime;
        characterController.Move(velocity);
    }
}
