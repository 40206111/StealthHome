using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HouseObstacle : MonoBehaviour
{
    //Sprite renderer
    private SpriteRenderer sr;

    //Variables to be changed within Unity
    [SerializeField]
    private Sprite lightsOff;      //sprite with lights off
    [SerializeField]
    private Sprite lightsOn;        //sprite with lights on
    [SerializeField]
    float minWait = 1.0f;           //minimum wait until light can come on again
    [SerializeField]
    float chance = 0.1f;            //chance of light coming on
    [SerializeField]
    float onWaitMin = 0.5f;         //minimum wait until light turns off
    [SerializeField]
    float onWaitMax = 1.5f;         //maximum wait until light turns off
    [SerializeField]
    float checkFreq = 1.0f;         //how often to check if light has turned on

    //Is light on
    public bool lightUp = false;
    private float timeElapsed = 0.0f;
    private float randomOnTime = 0.0f;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        //Check if light goes on
        if (!lightUp && timeElapsed > minWait)
        {
            StartCoroutine(Light());
        }
        else if (lightUp)
        {
            if (timeElapsed >= randomOnTime)
            {
                timeElapsed = 0.0f;
                lightUp = false;
                sr.sprite = lightsOff;
            }

        }


    }

    private IEnumerator Light()
    {
        //don't check every frame
        yield return new WaitForSeconds(checkFreq);

        float CheckLight = Random.Range(0.0f, 1.0f);
        if (CheckLight <= chance)
        {
            sr.sprite = lightsOn;
            lightUp = true;
            timeElapsed = 0.0f;
            randomOnTime = Random.Range(onWaitMin, onWaitMax);
        }
    }
}
