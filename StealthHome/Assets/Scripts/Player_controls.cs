﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Player_controls : MonoBehaviour
{
    [SerializeField]
    ControlHandler ch;
    AlertBar alertBar;

    Rigidbody2D player;

    const float movement_speed = 80.0f;
    const float sprint_speed = 160.0f;

    Footsteps steps;

    //animator
    private Animator anim;
    //Sprite renderer
    private SpriteRenderer sr;

    public bool disable = false;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        steps = gameObject.GetComponent<Footsteps>();

        alertBar = GameObject.FindGameObjectWithTag("AlertBar").GetComponent<AlertBar>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (disable) return;

        if (ch.MoveRight || ch.MoveLeft)
        {
            if (ch.Sprint)
                anim.SetBool("Run", true);
            else
            {
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
            }
            steps.WalkSound();
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }

        if (ch.MoveRight)
        {
            if (sr.flipX)
            {
                sr.flipX = false;
            }
            float speed = movement_speed;
            if (ch.Sprint)
                speed = sprint_speed;
            player.velocity = new Vector2(speed * Time.deltaTime, player.velocity.y);
        }
        if (ch.MoveLeft)
        {
            if (!sr.flipX)
            {
                sr.flipX = true;
            }
            float speed = movement_speed;
            if (ch.Sprint)
                speed = sprint_speed;
            player.velocity = new Vector2(-speed * Time.deltaTime, player.velocity.y);
        }
        if (!ch.MoveLeft && !ch.MoveRight)
            player.velocity = new Vector2(0.0f, player.velocity.y);


        if (ch.Crouch)
        {
            player.velocity = new Vector2(0.0f, 0.0f);
            /////////////// Play animation for coruching;
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Crouch", true);
        }
        else
        {
            anim.SetBool("Crouch", false);
        }

        // Increase alert if running
        if (anim.GetBool("Run"))
            alertBar.IncrementAlertLevel(0.1f * Time.deltaTime);
    }
}