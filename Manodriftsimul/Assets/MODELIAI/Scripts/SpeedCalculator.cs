using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCalculator : MonoBehaviour
{
    public float Speed;
    public Rigidbody rb;

    public Text SpeedText;
    public Text GearText;
    public Text RPMText;

    // Conversion factor from meters per second to kilometers per hour
    private const float MpsToKph = 3.6f;

    void FixedUpdate()
    {
        Vector3 vel = rb.velocity;
        Speed = rb.velocity.magnitude * MpsToKph;

        SpeedText.text = Speed.ToString("0");
    }
}