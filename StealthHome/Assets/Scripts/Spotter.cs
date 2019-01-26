using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotter : MonoBehaviour
{
    private Rigidbody2D house;
    [SerializeField] private float spotDistance = 1.5f;

    public bool Spotted;

    private void Start ()
    {
        house = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update ()
    {
        //Vector2 difference = gameObject.transform.position - house.transform.position;
        float dist = Mathf.Abs(gameObject.transform.position.x - house.transform.position.x);

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