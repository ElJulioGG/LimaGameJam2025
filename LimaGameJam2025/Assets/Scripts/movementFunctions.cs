using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movementFunctions : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject groundCol;
    private lookFunctions _look;
    private CharacterController playerController;
    private Vector3 playerVelocity;
    

    [Header ("Movement Parameters")]
    [SerializeField, Range(0f, 20f)] public float targetPlayerSpeed = 10.0f;

    //[SerializeField, Range(0f, 20f)] public float currentPlayerSpeed = 0.0f;
    //[SerializeField, Range(0f, 20f)] public float accelerationRate = 0.5f;
    //[SerializeField, Range(0f, 20f)] public float decelerationRate = 0.2f;
    [SerializeField] public bool isMoving;

    [Header ("Jump Parameters")]
    [SerializeField] private float worldGravity = -9.8f;
    [SerializeField] public bool isGrounded;
    [SerializeField, Range(0f, 20f)] private float targetJumpVelocity = 6.0f;
    [SerializeField] private float coyoteTime = 0.3f;
    [SerializeField] private float coyoteTimeCounter;
    [SerializeField] private float jumpBufferTime = 0.3f;
    [SerializeField] private float jumpBufferCounter;
    [SerializeField] private bool canJump = false;
    [SerializeField] public bool hasLanded = false;
    [SerializeField] private float airTimeCounter = 0.0f;

    void Start()
    {
        _look = GetComponent<lookFunctions>();
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {

        isGrounded = playerController.isGrounded;

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;

            if (airTimeCounter > 0)
            {

                if (airTimeCounter < 1.75)
                {
                    AudioManager.instance.PlaySfx("land_soft");
                }
                else
                {
                    //screen shake de aterrizaje fuerte

                    AudioManager.instance.PlaySfx("land_hard");
                    AudioManager.instance.PlayBark("land_hard_voice");
                    AudioManager.instance.PlaySfx("land_hard_emphasizer");
                }
                
            }

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

            airTimeCounter += Time.deltaTime;
            if (airTimeCounter > 5)
            {
                airTimeCounter = 5;
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
        Vector3 moveDir = input.x * _look.Right + input.y * _look.Forward;
        playerController.Move(moveDir * targetPlayerSpeed * Time.deltaTime);

        //Movimiento
        if (input.x != 0 || input.y != 0)
        {
            animator.SetBool("Running", true);
            print("Running");
            //.. en TIERRA
            if (isGrounded)
            {
                if (AudioManager.instance.FootStepsSource.isPlaying == false)
                {
                    AudioManager.instance.PlayFootSteps("run_clean");
                }
            }
            else
            {
                AudioManager.instance.FootStepsSource.Stop();
            }
        }
        //No movimiento
        else
        {
            animator.SetBool("Running", false);
            print("NotRunnig");
            AudioManager.instance.FootStepsSource.Stop();
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
            //Invoke("activateGroundCollider", 0.2f);
            playerVelocity.y = targetJumpVelocity;
            canJump = false;

            //int jumpSoundSelect = Random.Range(1, 4);
            AudioManager.instance.PlayDoor("jump1");

        }
        else
        {
            jumpBufferCounter = jumpBufferTime;
            
            if (coyoteTimeCounter > 0 && canJump)
            {
                playerVelocity.y = targetJumpVelocity;
                coyoteTimeCounter = 0;
                canJump = false;

                int jumpSoundSelect = Random.Range(1, 4);
                AudioManager.instance.PlayDoor("jump" + jumpSoundSelect.ToString());
            }
        }
    }
    //private void acivateGroundCollider()
    //{
    //    groundCol.SetActive(true);
    //}
}
