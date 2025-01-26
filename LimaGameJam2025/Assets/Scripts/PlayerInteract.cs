using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform camPlayer;
    [SerializeField] public float raycastDistance = 5f;
    [SerializeField] private float raycastHeightOffset = 0.5f;
    public LayerMask layerMask;

    void Update()
    {
        Vector3 rayDirection = camPlayer.forward;

        // Ajusta la posición Y de origen del Raycast
        Vector3 rayOrigin = transform.position + new Vector3(0, raycastHeightOffset, 0);

        // Realiza el Raycast
        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo, raycastDistance, layerMask))
        {
            // Si golpea un objeto en la capa especificada
            Debug.DrawRay(rayOrigin, rayDirection * raycastDistance, Color.green); // Raycast verde
        }
        else
        {
            // Si no golpea ningún objeto
            Debug.DrawRay(rayOrigin, rayDirection * raycastDistance, Color.red); // Raycast rojo
        }
    }
}