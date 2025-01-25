using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementFunctions : MonoBehaviour
{
    private CharacterController playerController;
    private Vector3 playerVelocity;

    [Header ("Movement Parameters")]
    [SerializeField, Range(0f, 20f)] private float playerSpeed;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;
        playerController.Move(transform.TransformDirection(moveDir) * playerSpeed * Time.deltaTime);
    }
}
