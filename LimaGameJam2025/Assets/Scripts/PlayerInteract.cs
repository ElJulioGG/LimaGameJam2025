using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform camPlayer;
    [SerializeField] public float raycastDistance = 5f;
    public LayerMask layerMask;

    void Update()
    {
        Vector3 rayDirection = camPlayer.forward;

        // Realiza el Raycast
        if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hitInfo, raycastDistance, layerMask))
        {
            // Si golpea un objeto en la capa especificada
            Debug.DrawRay(transform.position, rayDirection * raycastDistance, Color.green); // Raycast verde
        }
        else
        {
            // Si no golpea ningún objeto
            Debug.DrawRay(transform.position, rayDirection * raycastDistance, Color.red); // Raycast rojo
        }
    }
}