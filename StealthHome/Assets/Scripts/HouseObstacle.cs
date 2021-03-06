﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class HouseObstacle : MonoBehaviour
{
    // Variables for alerting
    private AlertBar Alert;
    private Spotter spotter;

    private enum State
    {
        Off,
        Inbetween,
        On
    }

    //animator
    private Animator anim;
    [SerializeField]
    private Animator animIcons;

    private Light light;

    //Variables to be changed within Unity
    [SerializeField]
    private float minWait = 1.0f;           //minimum wait until light can come on again
    [SerializeField]
    private float maxWait = 10.0f;           //maximum wait until light can come on again
    [SerializeField]
    private float chance = 0.1f;            //chance of light coming on
    [SerializeField]
    private float onWaitMin = 0.5f;         //minimum wait until light turns off
    [SerializeField]
    private float onWaitMax = 1.5f;         //maximum wait until light turns off
    [SerializeField]
    private float checkFreq = 1.0f;         //how often to check if light has turned on
    [SerializeField]
    private float warning = 1.0f;

    //Is light on
    private float timeElapsed = 0.0f;
    private float randomOnTime = 0.0f;
    private float totalWait = 0.0f;
    private State stage = State.Off;

    //Get if light is on from different class
    public bool IsLightOn()
    {
        if (stage == State.On)
        {
            return true;
        }
        return false;
    }

    void Start()
    {
        // Allerting variable initialisation
        Alert = GameObject.FindGameObjectWithTag("AlertBar").GetComponent<AlertBar>();
        spotter = gameObject.GetComponent<Spotter>();

        anim = gameObject.GetComponent<Animator>();
        //animIcons = gameObject.GetComponentInChildren<Animator>();
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        //Check if light goes on
        if (stage == State.Off && timeElapsed > totalWait)
        {
            StartCoroutine(Light());
        }
        else if (stage == State.Inbetween && timeElapsed >= warning)
        {
            timeElapsed = 0.0f;
            anim.SetInteger("Stage", (int)State.On);
            animIcons.SetBool("Wake", true);
            light.intensity = 0.7f;
            stage = State.On;

        }
        else if (stage == State.On)
        {
            if (timeElapsed >= randomOnTime)
            {
                timeElapsed = 0.0f;
                stage = State.Off;
                light.intensity = 0;
                anim.SetInteger("Stage", (int)State.Off);
                animIcons.SetBool("Sleep", true);
                animIcons.SetBool("Wake", false);
                totalWait = Random.Range(minWait, maxWait);
            }

        }

        // Player is seen moving
        if (stage == State.On && spotter.Spotted)
        {
            Alert.IncrementAlertLevel(0.1f * Time.deltaTime);
        }
    }

    private IEnumerator Light()
    {
        //don't check every frame
        yield return new WaitForSeconds(checkFreq);

        float CheckLight = Random.Range(0.0f, 1.0f);
        if (CheckLight <= chance)
        {
            animIcons.SetBool("Sleep", false);
            anim.SetInteger("Stage", (int)State.Inbetween);
            stage = State.Inbetween;
            light.intensity = 0.3f;
            timeElapsed = 0.0f;
            randomOnTime = Random.Range(onWaitMin, onWaitMax);
        }
    }
}
