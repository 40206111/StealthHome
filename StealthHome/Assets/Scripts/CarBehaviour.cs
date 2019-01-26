using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{

    [SerializeField] private AlertBar Alert;
    [SerializeField] private float maxSpeed = 75;
    Rigidbody2D rb;
    int dir;

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
        rb.velocity = new Vector2 (dir * maxSpeed * Time.deltaTime, 0);

    }
}