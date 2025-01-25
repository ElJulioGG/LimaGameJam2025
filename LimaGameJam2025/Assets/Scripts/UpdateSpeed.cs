using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpeed : MonoBehaviour
{
    [SerializeField] private movementFunctions movementScript;
    [SerializeField, Range(0f, 10f)] private float accelerationRate;
    [SerializeField, Range(0f, 10f)] private float decelerationRate;
    [SerializeField, Range(0f, 10f)] private float decelerationThreshold;

    private float currentSpeed;
    private bool isMoving;

    void Update()
    {
        // Verifica si se est� presionando alguna tecla de movimiento
        isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        // Aumenta la velocidad si se est� moviendo
        if (isMoving)
        {
            currentSpeed += accelerationRate * Time.deltaTime;
        }
        // Disminuye la velocidad si no se est� moviendo
        else
        {
            if (currentSpeed > decelerationThreshold)
            {
                currentSpeed -= (decelerationRate/2) * Time.deltaTime;
            }
            else
            {
                currentSpeed -= decelerationRate * Time.deltaTime;
            }
            
        }

        // Ajusta la velocidad para que no baje de 5
        currentSpeed = Mathf.Max(currentSpeed, 5f);

        movementScript.currentPlayerSpeed = currentSpeed;
    }
}