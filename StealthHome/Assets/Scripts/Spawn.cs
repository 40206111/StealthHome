using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject Spottable;
    // Start is called before the first frame update
    void Start ()
    {

    }

    void Spawn ()
    {

        Instantiate (Spottable);
    }

    IEnumerator timer ()
    {
        yield return new WaitForSeconds (5);

    }
}