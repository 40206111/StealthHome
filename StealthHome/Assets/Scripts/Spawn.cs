﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> Cars;
    [SerializeField] private float minSpawnTime = 20.0f;
    [SerializeField] private float maxSpawnTime = 35.0f;

    Vector2 cam;
    Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start ()
    {
        cam = Camera.main.transform.position;
        spawnPoints = gameObject.GetComponentsInChildren<Transform> ();
        StartCoroutine (timer ());
    }

    private void Update ()
    {
        //follow camera
        gameObject.transform.position = cam;
    }

    void Create ()
    {
        //modifier for positive or negative chosen at random
        float coin = Random.Range (-1.0f, 1.0f);
        int mod = Mathf.RoundToInt (coin);
        Transform sp;
        if (mod >= 0)
            sp = spawnPoints[2];
        else
            sp = spawnPoints[1];

        int r = Random.Range (0, Cars.Count);
        Instantiate (Cars[r], sp);
    }

    IEnumerator timer ()
    {
        float secs = Random.Range (minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds (secs);
        Create ();
        StartCoroutine (timer ());

    }
}