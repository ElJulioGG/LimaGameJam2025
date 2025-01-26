using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShakeEffect : MonoBehaviour
{
    [SerializeField] private CinemachineShake cinemachineShake; // Referencia al script CinemachineShake
    [SerializeField] private LayerMask mapLayer; // LayerMask para el mapa
    [SerializeField] private float shakeIntensityMultiplier = 1.0f; // Multiplicador de la intensidad de la sacudida
    [SerializeField] private float shakeDuration = 0.5f; // Duración de la sacudida

    public float maxJumpHeight = 0f; // Altura máxima del salto actual (ahora es pública)
    private bool isFalling = false; // Indica si el personaje está cayendo

    public void CalculateMaxJumpHeight()
    {
        // Raycast hacia abajo para detectar la altura máxima
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, mapLayer))
        {
            // Actualiza la altura máxima si el personaje está subiendo
            if (hit.point.y > maxJumpHeight)
            {
                maxJumpHeight = hit.point.y;
            }
        }
    }

    private void Update()
    {
        CalculateMaxJumpHeight(); // Llama al método para actualizar la altura máxima cada cuadro

        // Detecta si el personaje está cayendo
        if (!isFalling && transform.position.y < maxJumpHeight)
        {
            isFalling = true;

            // Aplica la sacudida de la cámara
            cinemachineShake.ShakeCamera(maxJumpHeight * shakeIntensityMultiplier, shakeDuration);

            // Restablece la altura máxima para el próximo salto
            maxJumpHeight = 0f;
        }
    }
}