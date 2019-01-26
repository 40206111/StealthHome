using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject Spottable;

    Transform camOffset;
    // Start is called before the first frame update
    void Start ()
    {
        camOffset = Camera.main.transform;
        StartCoroutine (timer ());
    }

    void Create ()
    {
        //modifier for positive or negative chosen at random
        int mod = Random.Range (-1, 1);
        if (mod >= 0)
            mod = 1;
        if (mod < 0)
            mod = -1;

        camOffset.position += new Vector3 (Camera.main.transform.position.x + 2 * mod, -1.5f, 0);

        Instantiate (Spottable, camOffset);
    }

    IEnumerator timer ()
    {
        float secs = Random.Range (0, 10);
        yield return new WaitForSeconds (secs);
        Create ();
        StartCoroutine (timer ());

    }
}