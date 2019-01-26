﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotter : MonoBehaviour
{
    [SerializeField] private Rigidbody2D house;
    [SerializeField] private float spotDistance = 1.5f;

    public bool Spotted;

    // Update is called once per frame
    void Update ()
    {
        Vector2 difference = gameObject.transform.position - house.transform.position;
        float dist = difference.magnitude;

        //if 30 units away or less and house is moving trigger public paramenter Spotted to equal true
        if (dist <= spotDistance && house.velocity != new Vector2 (0, 0))
        {
            Spotted = true;
            print ("Spot");
        }
        else
        {
            Spotted = false;
        }
    }
}