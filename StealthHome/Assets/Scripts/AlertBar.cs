using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertBar : MonoBehaviour
{
    private bool cooldown;

    [SerializeField] private float regenRate = 0.005f;
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
        cooldown = false;
        StartCoroutine (timer (3.0f));
    }

    private void Update ()
    {
        //make sure Alert level does not exceed 0 or 1
        AlertLevel = Mathf.Clamp (AlertLevel, 0, 1);

        if (cooldown)
        {
            AlertLevel -= regenRate;
        }

        //set fil level to match AlertLevel
        bar.fillAmount = AlertLevel;
    }

    IEnumerator timer (float secs)
    {
        yield return new WaitForSeconds (secs);
        cooldown = true;
    }
}