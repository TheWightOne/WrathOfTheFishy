using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{
    private Controls controls;
    private Vector2 movementInput;
    private bool sprintInput;

    [SerializeField]private CharacterController characterController = null;
    [SerializeField]private Transform cam = null;
    //the current speed the player should move
    private float currentSpeed = 0;

    //the default non-print speed
    [SerializeField]private float speed = 6f;

    //the sprint speed
    [SerializeField]private float sprintSpeed = 12f;
    [SerializeField]private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    [SerializeField]private float gravity = -9.81f;
    [SerializeField]private Transform groundCheck = null;
    //radius of the ground check sphere
    [SerializeField]private float groundDistance = 2f;
    [SerializeField]private LayerMask groundMask = 0;
    private bool isGrounded= false;
    private bool flying = false;
    [SerializeField]private float flightVelocity = 0f;
    private Vector3 velocity = new Vector3(0, 0, 0);

    public bool jumping = false;

    [Header("Jump Controls")]
    [SerializeField]private float jumpForce;
    [SerializeField]private float maxJumpTime;



    [SerializeField]private Animator animator = null;


    // Start is called before the first frame update
    void Awake()
    {
        controls = new Controls();
        controls.General.Movement.performed += ctx =>{
            movementInput = ctx.ReadValue<Vector2>();

        }; 
        controls.General.Sprint.performed += ctx => 
        {
            animator.SetBool("sprinting", true);
            
            currentSpeed = sprintSpeed;   
        };
        controls.General.Sprint.canceled += _ => {
            animator.SetBool("sprinting", false);
            
            currentSpeed = speed;
        };
        controls.General.Fly.performed += _ =>{
            Debug.Log("hit fly button!");
            flying = true;
        };
        controls.General.Fly.canceled += _ =>{
            flying = false;
        };
        controls.General.Jump.performed += _ =>{
            if(jumping){
                return;
            }
            jumpCoroutine = StartCoroutine(Jump());
        };
        controls.General.Jump.canceled += _ =>{
            if(jumpCoroutine != null){
                //Debug.Log("Stopping coroutine because button was released");
                StopCoroutine(jumpCoroutine);
                checkingForGrounded = true;
                if(velocity.y > 0f){
                    velocity.y = 0;
                }
                animator.SetBool("Falling", true);
            }else{
                return;
            }
        };
    }

    private Coroutine jumpCoroutine = null;
    private bool checkingForGrounded = false;

    #region - Enable/Disable -
    void OnEnable(){
        controls.Enable();
    }

    void OnDisable(){
        controls.Disable();
    }

    #endregion


    void Start(){
        currentSpeed = speed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //checks if the player is grounded. if so, reset fall velocity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);




        //characterController.Move(velocity);

        //input by the player
        Vector3 moveVector = new Vector3(movementInput.x, 0, movementInput.y);

        animator.SetFloat("speed", moveVector.sqrMagnitude);
        //Debug.Log(moveVector.sqrMagnitude);

        if(moveVector.sqrMagnitude <= 0.1f){
            return;
        }

        

        
      
        
        float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;        

        characterController.Move(moveDir.normalized * currentSpeed * Time.deltaTime);

        
        if(checkingForGrounded){
            if(isGrounded){
                jumping = false;
                animator.SetBool("Falling", false);
            }else{
            }
        }else{
                velocity.y += gravity * Time.deltaTime * Time.deltaTime;

        }
        
        characterController.Move(velocity);
    }


    public IEnumerator Jump(){
        checkingForGrounded = false;
        //Debug.Log("starting jump cor");
        jumping = true;
        animator.SetTrigger("Jump");
        float jumpTime = 0f;
        velocity.y = jumpForce/10;
        while(jumpTime < maxJumpTime){
            if(jumpTime > maxJumpTime/2){
                checkingForGrounded = true;
            }
            jumpTime += Time.fixedDeltaTime;
            velocity.y += gravity * jumpForce * Time.deltaTime *Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        //Debug.Log("stopping jump cor because of exceeded jump time");
        if(velocity.y > 0f){
            velocity.y = 0;
        }
        animator.SetBool("Falling", true);
        jumpCoroutine = null;
    }

    void OnDeath(){
        enabled = false;
    }

}
