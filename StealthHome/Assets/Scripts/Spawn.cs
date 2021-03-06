﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> Cars;
    [SerializeField] private float minSpawnTime = 20.0f;
    [SerializeField] private float maxSpawnTime = 35.0f;

    Transform cam;
    Transform[] spawnPoints;
    private int prevmod;
    private int consecutives;
    // Start is called before the first frame update
    void Start ()
    {
        cam = Camera.main.transform;
        spawnPoints = gameObject.GetComponentsInChildren<Transform> ();
        StartCoroutine (timer ());
    }

    private void Update ()
    {
        //follow camera
        gameObject.transform.position = new Vector3(cam.position.x, cam.position.y, 0.0f);
    }

    void Create ()
    {
        //modifier for positive or negative chosen at random
        float coin = Random.Range (-1.0f, 1.0f);
        int mod;
        mod = coin >= 0 ? 1 : -1;

        //have no more than 2 cars from the same direction one after the other
        if (mod == prevmod)
        {
            consecutives++;
        }
        if (consecutives >= 2)
        {
            mod = mod * -1;
            consecutives = 0;
        }

        Transform sp;
        if (mod >= 0)
            sp = spawnPoints[2];
        else
            sp = spawnPoints[1];

        int r = Random.Range (0, Cars.Count);
        Instantiate (Cars[r], sp.position + new Vector3 (0, -1, 0), sp.rotation);

        prevmod = mod;
    }

    IEnumerator timer ()
    {
        float secs = Random.Range (minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds (secs);
        Create ();
        StartCoroutine (timer ());

    }
}