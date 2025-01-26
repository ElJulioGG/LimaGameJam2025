using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShakeEffect : MonoBehaviour
{
    [SerializeField] private CinemachineShake cinemachineShake; // Referencia al script CinemachineShake
    [SerializeField] private LayerMask mapLayer; // LayerMask para el mapa
    [SerializeField] private float shakeIntensityMultiplier = 1.0f; // Multiplicador de la intensidad de la sacudida
    [SerializeField] private float shakeDuration = 0.5f; // Duraci�n de la sacudida

    public float maxJumpHeight = 0f; // Altura m�xima del salto actual (ahora es p�blica)
    private bool isFalling = false; // Indica si el personaje est� cayendo

    public void CalculateMaxJumpHeight()
    {
        // Raycast hacia abajo para detectar la altura m�xima
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, mapLayer))
        {
            // Actualiza la altura m�xima si el personaje est� subiendo
            if (hit.point.y > maxJumpHeight)
            {
                maxJumpHeight = hit.point.y;
            }
        }
    }

    private void Update()
    {
        CalculateMaxJumpHeight(); // Llama al m�todo para actualizar la altura m�xima cada cuadro

        // Detecta si el personaje est� cayendo
        if (!isFalling && transform.position.y < maxJumpHeight)
        {
            isFalling = true;

            // Aplica la sacudida de la c�mara
            cinemachineShake.ShakeCamera(maxJumpHeight * shakeIntensityMultiplier, shakeDuration);

            // Restablece la altura m�xima para el pr�ximo salto
            maxJumpHeight = 0f;
        }
    }
}