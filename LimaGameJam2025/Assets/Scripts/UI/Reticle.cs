using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    private RectTransform reticle;

    [Header("Reticle Settings")]
    public float restingSize = 50f; // Tamaño base de la retícula
    public float maxSize = 100f;    // Tamaño máximo al moverse
    public float speed = 5f;        // Velocidad de interpolación
    private float currentSize;      // Tamaño actual de la retícula

    private void Start()
    {
        reticle = GetComponent<RectTransform>();
        Cursor.visible = false;   // Oculta el cursor
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
        currentSize = restingSize; // Inicializa la retícula con su tamaño base
    }

    private void Update()
    {
        // Verifica si el jugador se está moviendo
        if (IsMoving())
        {
            // Incrementa el tamaño de la retícula hacia el máximo
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
        }
        else
        {
            // Reduce el tamaño de la retícula hacia el tamaño base
            currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed);
        }

        // Actualiza el tamaño de la retícula
        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }

    private bool IsMoving()
    {
        // Detecta si el jugador está moviéndose con teclado o mouse
        return Input.GetAxis("Horizontal") != 0 ||
               Input.GetAxis("Vertical") != 0 ||
               Input.GetAxis("Mouse X") != 0 ||
               Input.GetAxis("Mouse Y") != 0;
    }
}
