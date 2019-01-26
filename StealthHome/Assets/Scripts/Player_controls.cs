using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controls : MonoBehaviour
{
    [SerializeField]
    ControlHandler ch;

    Rigidbody2D player;

    const float movement_speed = 80.0f;
    const float sprint_speed = 130.0f;

    // Start is called before the first frame update
    void Start ()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (ch.MoveRight)
        {
            float speed = movement_speed;
            if (ch.Sprint)
                speed = sprint_speed;
            player.velocity = new Vector2 (speed * Time.deltaTime, player.velocity.y);
        }
        if (ch.MoveLeft)
        {
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
        }
    }
}