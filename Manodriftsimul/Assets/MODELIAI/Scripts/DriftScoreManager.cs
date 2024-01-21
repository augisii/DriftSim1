using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DriftScoreManager : MonoBehaviour
{
    public WheelController wheelController;
    public TextMeshProUGUI driftScoreText;
    public TextMeshProUGUI multiplierText;

    private float driftScore;
    private float driftMultiplier;
    private bool isDrifting;
    public float initialDriftMultiplier = 1.0f;
    public float driftMultiplierIncreaseRate = 0.1f;

    // Update is called once per frame
    void Update()
    {
        CalculateDriftScore();
        UpdateDriftScoreText();
        UpdateMultiplierText();
    }

    void CalculateDriftScore()
    {
        float driftFactor = Mathf.Abs(wheelController.Horizontal);

        if (driftFactor > 0.1f) // If drifting to the side
        {
            isDrifting = true;

            // Add your drift score calculation logic here
            // For example, you can use the wheel's rotation speed or other parameters
            // In this example, a simple calculation is used for demonstration purposes.
            driftScore += driftFactor * Time.deltaTime * (initialDriftMultiplier + driftMultiplier);

            // Increase the drift multiplier immediately when drifting
            driftMultiplier += driftMultiplierIncreaseRate * Time.deltaTime;
        }
        else // If not drifting
        {
            if (isDrifting)
            {
                // Reset the drift multiplier when drifting ends
                driftMultiplier = 0;
                isDrifting = false;
            }
        }
    }

    void UpdateDriftScoreText()
    {
        driftScoreText.text = "Drift Score:\n" + Mathf.Round(driftScore);
    }

    void UpdateMultiplierText()
    {
        multiplierText.text = "Multiplier:\n" + Mathf.Round(driftMultiplier * 10) / 10f;
    }
}
