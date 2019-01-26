using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{

    [SerializeField] private AlertBar Alert;
    [SerializeField] private float maxSpeed = 75;
    Rigidbody2D rb;

    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update ()
    {
        rb.velocity = new Vector2 (-maxSpeed * Time.deltaTime, 0);

    }
}