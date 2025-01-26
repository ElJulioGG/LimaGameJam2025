using System.Collections;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] private GameObject areaAWarn;
    [SerializeField] private GameObject areaAWarnText;
    [SerializeField] private bool isInZone =false;
    [SerializeField] private float timer;
    [SerializeField] private bool warningActive;

    void Start()
    {
        isInZone = true; // Assume player starts in the zone
        timer = 0f;
        warningActive = false;
        areaAWarn.SetActive(false);
        areaAWarnText.SetActive(false);
    }

    void Update()
    {
        if (!isInZone)
        {
            timer += Time.deltaTime;

            // Display warnings after 10 seconds
            if (timer >= 10f && !warningActive)
            {
                areaAWarn.SetActive(true);
                areaAWarnText.SetActive(true);
                warningActive = true;
            }

            // Lose condition after 20 seconds
            if (timer >= 20f)
            {
                areaAWarn.SetActive(false);
                areaAWarnText.SetActive(false);
                warningActive = false;
                Debug.Log("Lose");
                timer = 0f; // Reset the timer
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("inZone");
            isInZone = true;

            // Reset everything when the player re-enters
            areaAWarn.SetActive(false);
            areaAWarnText.SetActive(false);
            warningActive = false;
            timer = 0f;
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false; // Player has exited the zone
        }
    }
}
