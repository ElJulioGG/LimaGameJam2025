using UnityEngine;
using TMPro;

public class CooldownTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText; // Texto para mostrar el temporizador
    [SerializeField] private float cooldownTime = 1800f; // Tiempo inicial en segundos (30 minutos)
    private float currentTime;
    private bool isCooldownActive;

    void Start()
    {
        currentTime = cooldownTime; // Inicializa el tiempo actual
        isCooldownActive = true; // Inicia el temporizador
    }

    void Update()
    {
        if (isCooldownActive)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime; // Reduce el tiempo restante
                UpdateTimerText();
            }
            else
            {
                currentTime = 0;
                isCooldownActive = false;
                TriggerCooldownEnd(); // Llama a la función al llegar a 0
            }
        }
    }

    private void UpdateTimerText()
    {
        // Convierte el tiempo restante en formato mm:ss
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void TriggerCooldownEnd()
    {
        Debug.Log("¡Cooldown finalizado! Activando acción...");
        // Aquí puedes ejecutar cualquier acción, como activar un objeto o desencadenar un evento
        ActivateAction();
    }

    private void ActivateAction()
    {
        // Ejemplo de acción personalizada
        Debug.Log("¡Acción activada!");
    }
}
