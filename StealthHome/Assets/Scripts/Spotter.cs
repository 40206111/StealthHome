using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotter : MonoBehaviour
{
    private Rigidbody2D house;
    [SerializeField] private float spotDistance = 1.5f;
    private ControlHandler ch;
    private AlertBar ab;

    public bool Spotted;

    private void Start ()
    {
        house = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
        ch = GameObject.FindGameObjectWithTag("Controls").GetComponent<ControlHandler>();
        ab = GameObject.FindGameObjectWithTag("AlertBar").GetComponent<AlertBar>();
    }

    // Update is called once per frame
    void Update ()
    {
        //Vector2 difference = gameObject.transform.position - house.transform.position;
        float dist = Mathf.Abs(gameObject.transform.position.x - house.transform.position.x);

        //if 30 units away or less and house is moving trigger public paramenter Spotted to equal true
        if (dist <= spotDistance && !ch.Crouch)
        {
            Spotted = true;
        }
        else if (ch.Sprint && Mathf.Abs(house.velocity.x) > 0.0)
        {
            ab.IncrementAlertLevel(0.02f * Time.deltaTime);
        }
        else
        {
            Spotted = false;
        }
    }
}