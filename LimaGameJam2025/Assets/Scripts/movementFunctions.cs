using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movementFunctions : MonoBehaviour
{
    
    private lookFunctions _look;
    private CharacterController playerController;
    private Vector3 playerVelocity;
    

    [Header ("Movement Parameters")]
    [SerializeField, Range(0f, 20f)] public float targetPlayerSpeed = 10.0f;
    [SerializeField, Range(0f, 20f)] public float currentPlayerSpeed = 0.0f;
    [SerializeField, Range(0f, 20f)] public float accelerationRate = 0.5f;
    [SerializeField, Range(0f, 20f)] public float decelerationRate = 0.2f;
    [SerializeField] public bool isMoving;

    [Header ("Jump Parameters")]
    [SerializeField] private float worldGravity = -9.8f;
    [SerializeField] private bool isGrounded;
    [SerializeField, Range(0f, 20f)] private float jumpHeight;
    [SerializeField] private float coyoteTime = 0.3f;
    [SerializeField] private float coyoteTimeCounter;
    [SerializeField] private float jumpBufferTime = 0.5f;
    [SerializeField] private float jumpBufferCounter;
    [SerializeField] private bool canJump = false;
    [SerializeField] private float airTimeCounter = 0.0f;
    private float targetJumpVelocity = 0.0f;

    void Start()
    {
        _look = GetComponent<lookFunctions>();
        playerController = GetComponent<CharacterController>();
        targetJumpVelocity = Mathf.Sqrt(jumpHeight * -3.0f * worldGravity);
    }

    float GdMoveToward(float from, float to, float a)
    {
        return Mathf.Abs(to - from) <= a ? to : from + Mathf.Sign(to - from) * a;
    }

    void Update()
    {
        isGrounded = playerController.isGrounded;

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;

            CinemachineShake.Instance.ShakeCamera(airTimeCounter, 1f);

            airTimeCounter = 0;

            //Bandaid fix for the ghost double-jump bug
            if (playerVelocity.y > 0){
                canJump = false;
            }
            else{
                canJump = true;
            }

            if (jumpBufferCounter > 0)
            {
                Jump();
            }



        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;

            jumpBufferCounter -= Time.deltaTime;

            if (playerVelocity.y < 0)
            {   
                airTimeCounter += Time.deltaTime;
                if (airTimeCounter > 5)
                {
                    airTimeCounter = 5;
                }
            }

            if (coyoteTimeCounter < 0)
            {
                coyoteTimeCounter = 0;
                canJump = false;
            }

            if (jumpBufferCounter < 0)
            {
                jumpBufferCounter = 0;
            }
        }
    }

    public void ProcessMove(Vector2 input)
    {   
        //Horizontal Movement

        isMoving = input.x != 0 || input.y != 0;
        Vector3 moveDir = input.x * _look.Right + input.y * _look.Forward;

        if (isMoving)
        {
            playerVelocity.x = GdMoveToward(playerVelocity.x, moveDir.x * targetPlayerSpeed, accelerationRate);
            playerVelocity.z = GdMoveToward(playerVelocity.z, moveDir.z * targetPlayerSpeed, accelerationRate);
        }
        else
        {
            playerVelocity.x = GdMoveToward(playerVelocity.x, 0, decelerationRate);
            playerVelocity.z = GdMoveToward(playerVelocity.z, 0, decelerationRate);
        }


        //Progress gravity per frame
        playerVelocity.y += worldGravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            //gives an empty value to vel.y to nullify the effects of gravity
            playerVelocity.y = -2f;

        playerController.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void Jump(){
        //Incomplete maybe, if any jump-related bugs arise, check this "if" conditional first
        if (isGrounded)
        {   
            playerVelocity.y = targetJumpVelocity;
            canJump = false;
        }
        else
        {
            jumpBufferCounter = jumpBufferTime;
            
            if (coyoteTimeCounter > 0 && canJump)
            {
                playerVelocity.y = targetJumpVelocity;
                coyoteTimeCounter = 0;
                canJump = false;
            }
        }
    }
}
