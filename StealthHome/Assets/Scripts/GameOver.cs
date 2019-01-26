using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private AlertBar bar;
    private TextMeshProUGUI tmp;
    private Image img;
    private ButtonManager bm;
    private Rigidbody2D rb;

    public float EndTimer = 4;
    public bool Failed;
    // Start is called before the first frame update
    void Start ()
    {
        img = gameObject.GetComponent<Image> ();
        tmp = gameObject.GetComponentInChildren<TextMeshProUGUI> ();
        bar = GameObject.FindGameObjectWithTag ("AlertBar").GetComponent<AlertBar> ();
        bm = GameObject.Find ("ButtonManager").GetComponent<ButtonManager> ();
        rb = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update ()
    {
        if (bar.AlertLevel >= 1)
        {
            StartCoroutine (FailState ());
        }

        print ("wat");

        //freeze player and tick down untill load main menu
        if (Failed)
        {
            rb.velocity = new Vector2 (0, 0);
            EndTimer -= Time.deltaTime;
        }

        if (EndTimer <= 0 || (Failed && Input.anyKeyDown))
        {
            bm.StartMenu ();
        }
    }

    IEnumerator FailState ()
    {
        tmp.color = new Color (tmp.color.r, tmp.color.g, tmp.color.b, tmp.color.a + 3 * Time.fixedDeltaTime);
        img.color = new Color (0, 0, 0, img.color.a + 3 * Time.fixedDeltaTime);
        yield return Failed = true;
    }
}