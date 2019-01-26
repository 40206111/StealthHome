using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Player_controls : MonoBehaviour
{
    [SerializeField]
    ControlHandler ch;

    Rigidbody2D player;

    const float movement_speed = 80.0f;
    const float sprint_speed = 130.0f;

    //animator
    private Animator anim;
    //Sprite renderer
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start ()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (ch.MoveRight || ch.MoveLeft)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (ch.MoveRight)
        {
            if(sr.flipX)
            {
                sr.flipX = false;
            }
            float speed = movement_speed;
            if (ch.Sprint)
                speed = sprint_speed;
            player.velocity = new Vector2 (speed * Time.deltaTime, player.velocity.y);
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
            player.velocity = new Vector2 (-speed * Time.deltaTime, player.velocity.y);
        }
        if (!ch.MoveLeft && !ch.MoveRight)
            player.velocity = new Vector2(0.0f, player.velocity.y);
        if (ch.Crouch)
        {
            player.velocity = new Vector2 (0.0f, 0.0f);
            /////////////// Play animation for coruching;
            anim.SetBool("Walk", false);
            anim.SetBool("Crouch", true);
        }
        else
        {
            anim.SetBool("Crouch", false);
        }
    }
}