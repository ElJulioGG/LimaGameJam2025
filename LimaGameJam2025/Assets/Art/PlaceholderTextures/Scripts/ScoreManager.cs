using UnityEngine;
using TMPro;
using System.Collections;
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the TextMeshPro component for displaying the score
    public TMP_Text multiplierText; // Reference to the TextMeshPro component for displaying the multiplier
    public movementFunctions movement; // Reference to your player controller script

    public float score = 0; // Total score
    private float multiplier = 1; // Current multiplier
    private float pointsPerSecond = 1; // Base points earned per second
    private float holdPointsIncrement = 0; // Points increment while holding the mouse
    private float holdTime = 0; // Time the mouse button is held

    private void Start()
    {
        StartCoroutine(UpdateMultiplierCoroutine());
    }

    private void Update()
    {
        // Add points over time
        score += pointsPerSecond * multiplier * Time.deltaTime;

        // Check if the mouse button is held
        if (Input.GetMouseButton(0))
        {
            holdTime += Time.deltaTime;

            // Increment points per second every second of holding the button
            if (holdTime >= 1f)
            {
                holdPointsIncrement++;
                holdTime = 0f; // Reset the timer
            }

            // Add hold-based points every 0.2 seconds
            score += (pointsPerSecond + holdPointsIncrement) * multiplier * Time.deltaTime * 5f;
        }
        else
        {
            holdTime = 0f;
            holdPointsIncrement = 0f;
        }

        // Update the UI
        UpdateUI();
    }

    private IEnumerator UpdateMultiplierCoroutine()
    {
        while (true)
        {
            UpdateMultiplier();
            yield return new WaitForSeconds(0.05f); // Wait 0.05 seconds before updating again
        }
    }

    private void UpdateMultiplier()
    {
        multiplier = 1f;

        // Example conditions from movementFunctions
        if (movement.isMoving)
            multiplier += 0.5f; // Add 1.5x for moving

        if (Input.GetMouseButton(0)) // Check if mouse button is held for shooting
            multiplier += 1.5f; // Add 3x for shooting

        if (!movement.isGrounded) // Check if the player is in the air
            multiplier += 3f; // Add 32x for being in the air
    }

    private void UpdateUI()
    {
        print(score);
        scoreText.text = "000" + Mathf.FloorToInt(score).ToString();
        multiplierText.text = "x" + multiplier.ToString("F1");
    }
}
