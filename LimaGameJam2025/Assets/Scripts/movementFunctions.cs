using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementFunctions : MonoBehaviour
{
    private lookFunctions _look;
    private CharacterController playerController;
    private Vector3 playerVelocity;
    

    [Header ("Movement Parameters")]
    [SerializeField, Range(0f, 20f)] public float playerSpeed;
    
    [Header ("Jump Parameters")]
    [SerializeField] private float worldGravity = -9.8f;
    [SerializeField] private bool isGrounded;


    void Start()
    {
        _look = GetComponent<lookFunctions>();
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = playerController.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDir = input.x * _look.Right + input.y * _look.Forward;
        playerController.Move(moveDir * playerSpeed * Time.deltaTime);

        playerVelocity.y += worldGravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        playerController.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }
}
