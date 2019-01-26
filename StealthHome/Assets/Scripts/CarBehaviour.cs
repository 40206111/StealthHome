using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{

    [SerializeField] private AlertBar Alert;
    [SerializeField] private float maxSpeed = 75;
    Rigidbody2D rb;
    int dir;

    public bool Spotted = false;

    void Start ()
    {
        if (gameObject.transform.position.x - Camera.main.transform.position.x > 0)
            dir = -1;
        else
            dir = 1;
        rb = gameObject.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update ()
    {

        //debug
        if (Input.GetKeyDown ("space"))
        {
            Spotted = !Spotted;
        }

        if (!Spotted)
        {
            rb.velocity = new Vector2 (dir * maxSpeed * Time.deltaTime, 0);
        }
        else
        {
            int dirModifier = dir * -1;

            //slow down
            if (rb.velocity.x > 0 || rb.velocity.x < 0)
            {
                //rb.velocity += new Vector2 (0.1f * dirModifier, 0);
                rb.velocity = Vector2.Lerp (rb.velocity, new Vector2 (0, 0), 0.01f);
                Debug.ClearDeveloperConsole ();
                Debug.Log (rb.velocity.x);
            }

            if (rb.velocity.x < 0.1f && rb.velocity.x > 0 || rb.velocity.x > -0.1f && rb.velocity.x < 0)
            {
                rb.velocity = new Vector2 (0, 0);
            }

        }
    }
}