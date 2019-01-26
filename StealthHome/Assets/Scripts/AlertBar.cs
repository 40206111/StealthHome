using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertBar : MonoBehaviour
{

    [SerializeField] private Image bar;

    public float AlertLevel = 0; //{ get; private set; }

    void Start ()
    {
        AlertLevel = 0.0f;
        //bar = bar.GetComponentInChildren<Image> ();
        print (bar.name);
    }

    public void IncrementAlertLevel (float amount)
    {
        AlertLevel += amount;
    }

    private void Update ()
    {
        //make sure Alert level does not exceed 0 or 1
        AlertLevel = Mathf.Clamp (AlertLevel, 0, 1);

        //set fil level to match AlertLevel
        bar.fillAmount += AlertLevel;
    }
}