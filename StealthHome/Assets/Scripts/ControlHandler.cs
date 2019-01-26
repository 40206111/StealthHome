using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHandler : MonoBehaviour
{

    public bool MoveLeft { get; set; }
    public bool MoveRight { get; set; }
    public bool Sprint { get; set; }
    public bool Crouch { get; set; }

    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        //set move right bool
        if (Input.GetAxis ("Horizontal") > 0)
        {
            MoveRight = true;
        }
        else
        {
            MoveRight = false;
        }

        //set move left bool
        if (Input.GetAxis ("Horizontal") < 0)
        {
            MoveLeft = true;
        }
        else
        {
            MoveLeft = false;
        }

        //set sprint bool
        if (Input.GetAxis ("Sprint") > 0)
        {
            Sprint = true;
        }
        else
        {
            Sprint = false;
        }

        if (Input.GetAxis ("Crouch") > 0)
        {
            Crouch = true;
        }
        else
        {
            Crouch = false;
        }

        ////log states
        //if (MoveLeft)
        //    Debug.Log ("LEFT");
        //if (MoveRight)
        //    Debug.Log ("RIGHT");
        //if (Sprint)
        //    Debug.Log ("SPRINTING");
        //if (Crouch)
        //    Debug.Log ("CROUGHING");
    }
}