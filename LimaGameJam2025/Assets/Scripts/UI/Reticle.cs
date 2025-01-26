using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    private RectTransform reticle;

    [Header("Reticle Settings")]
    public float restingSize = 50f; // Tama�o base de la ret�cula
    public float maxSize = 100f;    // Tama�o m�ximo al moverse
    public float speed = 5f;        // Velocidad de interpolaci�n
    private float currentSize;      // Tama�o actual de la ret�cula

    private void Start()
    {
        reticle = GetComponent<RectTransform>();
        Cursor.visible = false;   // Oculta el cursor
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
        currentSize = restingSize; // Inicializa la ret�cula con su tama�o base
    }

    private void Update()
    {
        // Verifica si el jugador se est� moviendo
        if (IsMoving())
        {
            // Incrementa el tama�o de la ret�cula hacia el m�ximo
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
        }
        else
        {
            // Reduce el tama�o de la ret�cula hacia el tama�o base
            currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed);
        }

        // Actualiza el tama�o de la ret�cula
        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }

    private bool IsMoving()
    {
        // Detecta si el jugador est� movi�ndose con teclado o mouse
        return Input.GetAxis("Horizontal") != 0 ||
               Input.GetAxis("Vertical") != 0 ||
               Input.GetAxis("Mouse X") != 0 ||
               Input.GetAxis("Mouse Y") != 0;
    }
}
