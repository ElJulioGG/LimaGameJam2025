using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private movementFunctions movementFunctions;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.onFoot;
        movementFunctions = GetComponent<movementFunctions>();
        onFoot.playerJump.performed += ctx => movementFunctions.Jump();
    }

    void Update()
    {
        movementFunctions.ProcessMove(onFoot.playerMovement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }

}
