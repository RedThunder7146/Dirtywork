using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movementscript : MonoBehaviour
{
    [Header("References")]
    private CharacterController characterController;
    [SerializeField] private Transform cam;
    [Header("Movement settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float turningSpeed = 2f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] public Animator anim;
    bool walk = false;
    bool walkOutside = false;
    private float verticalVelocity;

    [Header("Input actions")]
    public SanityBar sanityBar;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction lookAction;





    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        lookAction = InputSystem.actions.FindAction("Look");
    }
    private void Update()
    {

        Movement();
    }

    private void Movement()
    {
        GroundMovement();
        Turn();
    }

    private void GroundMovement()
    {

        Vector3 moveValue = moveAction.ReadValue<Vector3>();
        moveValue = transform.TransformDirection(moveValue);


        moveValue.y = VerticalForceCalculation();

        if ((moveValue.x != 0) || (moveValue.z != 0))
        {
            anim.SetBool("IsWalking", true);
            if (walk == false && sanityBar.sanityDrop == true)
            {
                AudioManager.instance.PlaySoundEffect("WalkOnWood");
                AudioManager.instance.StopSoundEffect("WalkOutside");
                walk = true;
            }

            if (walkOutside == false && sanityBar.sanityDrop ==  false)
            {
                AudioManager.instance.PlaySoundEffect("WalkOutside");
                walkOutside = true;
            }

        }
        else
        {
            anim.SetBool("IsWalking", false);
            walk = false;
            walkOutside = false;
            AudioManager.instance.StopSoundEffect("WalkOnWood");
            AudioManager.instance.StopSoundEffect("WalkOutside");
        }



        characterController.Move(moveValue* walkSpeed*Time.deltaTime);
    }

    private void Turn()
    {
        Vector3 moveVal = moveAction.ReadValue<Vector3>();
        moveVal.y = 0;

        
        Vector3 currentLookDirection = cam.forward;
        currentLookDirection.y = 0; 

        Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turningSpeed);
        
        
        
        
    }

    private float VerticalForceCalculation()
    {
        if(characterController.isGrounded)
        {

            verticalVelocity = -1f;

            if (jumpAction.IsPressed())
            {
                verticalVelocity = MathF.Sqrt(jumpHeight * gravity * 2);

                anim.SetBool("IsJumping", true);
                }

            else
                anim.SetBool("IsJumping", false);
        }

        else
        {
            verticalVelocity -= gravity * Time.deltaTime;

        }
        return verticalVelocity;
    }



    
}
