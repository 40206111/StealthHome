﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controls : MonoBehaviour
{
    [SerializeField]
    ControlHandler ch;

    const float movement_speed = 2.0f;
    const float sprint_speed = 3.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ch.right)
        {
            float speed = movement_speed;
            if (ch.sprint)
                speed = sprint_speed;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.deltaTime, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (ch.left)
        {
            float speed = movement_speed;
            if (ch.sprint)
                speed = sprint_speed;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * Time.deltaTime, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (ch.crouch)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            /////////////// Play animation for coruching;
        }
    }
}