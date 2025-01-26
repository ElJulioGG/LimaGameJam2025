using UnityEngine;
using TMPro; // Necesario para trabajar con TextMeshPro

public class Multiplier : MonoBehaviour
{
    // Referencias a los GameObjects de los multiplicadores
    public GameObject multiplierX1;
    public GameObject multiplierX2;
    public GameObject multiplierX4;

    // Referencia al texto de la UI donde se muestra el score (usando TMP_Text)
    public TMP_Text scoreText;

    private int score = 0; // Puntaje inicial
    private int multiplicador = 1; // Multiplicador actual (x1 por defecto)

    void Start()
    {
        // Desactivamos todos los multiplicadores al inicio
        DesactivarMultiplicadores();
        ActualizarPuntaje();
    }

    void Update()
    {
        // Activar multiplicadores con las teclas 1, 2, y 3
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivarMultiplicador(multiplierX1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivarMultiplicador(multiplierX2, 2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivarMultiplicador(multiplierX4, 4);
        }

        // Aquí puedes agregar cualquier lógica para aumentar el puntaje, por ejemplo:
        // Puntaje que aumenta según algún evento
        if (Input.GetKeyDown(KeyCode.Space)) // Por ejemplo, cada vez que presionas espacio, el puntaje aumenta
        {
            IncrementarPuntaje(10); // Sumar 10 al puntaje
        }
    }

    void ActivarMultiplicador(GameObject nuevoMultiplicador, int nuevoValorMultiplicador)
    {
        // Primero desactivamos todos los multiplicadores
        DesactivarMultiplicadores();

        // Activamos el multiplicador seleccionado
        nuevoMultiplicador.SetActive(true);

        // Establecer el nuevo multiplicador
        multiplicador = nuevoValorMultiplicador;

        // Actualizar el puntaje de acuerdo al multiplicador
        ActualizarPuntaje();

        Debug.Log("Multiplicador activado: " + nuevoMultiplicador.name);
    }

    void DesactivarMultiplicadores()
    {
        // Desactivar todos los multiplicadores
        multiplierX1.SetActive(false);
        multiplierX2.SetActive(false);
        multiplierX4.SetActive(false);
    }

    void IncrementarPuntaje(int cantidad)
    {
        // Incrementamos el puntaje según el multiplicador actual
        score += cantidad * multiplicador;
        ActualizarPuntaje();
    }

    void ActualizarPuntaje()
    {
        // Actualizamos el texto en la UI con el puntaje actual
        scoreText.text = "" + score.ToString();
    }
}
