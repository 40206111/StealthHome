using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertBar : MonoBehaviour
{

    public float AlertLevel { get; private set; }

    void Start ()
    {
        AlertLevel = 0.0f;
    }

    public void IncrementAlertLevel (float amount)
    {
        AlertLevel += amount;
    }
}