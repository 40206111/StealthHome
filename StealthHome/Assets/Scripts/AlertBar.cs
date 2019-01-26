using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertBar : MonoBehaviour
{
    private bool cooldown;
    [SerializeField] private float cooldownActivationWait = 5;
    private float timer;

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

        timer = cooldownActivationWait;

    }

    private void Update ()
    {
        //tick down until cooldown period activates
        timer -= Time.deltaTime;

        //if you've been undetected for the fuul cooldown wait then start cooling down
        if (timer<=0)
        {
            AlertLevel -= regenRate * Time.deltaTime;
        }


        //make sure Alert level does not exceed 0 or 1
        AlertLevel = Mathf.Clamp(AlertLevel, 0, 1);
        //set fil level to match AlertLevel
        bar.fillAmount = AlertLevel;
    }

   
}