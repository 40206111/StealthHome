using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{

    [SerializeField] private AlertBar Alert;
    [SerializeField] private float maxSpeed = 75;
    private Spotter spotter;

    Rigidbody2D rb;
    int dir;

    public bool Triggered = false;

    void Start ()
    {
        if (gameObject.transform.position.x - Camera.main.transform.position.x > 0)
            dir = -1;
        else
            dir = 1;

        //caching
        rb = gameObject.GetComponent<Rigidbody2D> ();
        spotter = gameObject.GetComponent<Spotter> ();
    }

    // Update is called once per frame
    void Update ()
    {

        //debug
        if (spotter.Spotted)
        {
            Triggered = true;
        }
        else
        {
            Triggered = false;
        }

        if (!Triggered)
        {
            rb.velocity = new Vector2 (dir * maxSpeed * Time.deltaTime, 0);
        }
        else
        {
            //bump alert level meter
            Alert.IncrementAlertLevel (0.1f * Time.deltaTime);

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