using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private AlertBar bar;
    private TextMeshProUGUI tmp;
    private Image img;
    private ButtonManager bm;
    private GameObject player;

    private AudioSource mainAudio = null;
    private AudioSource footsteps;

    public float EndTimer = 4;
    public bool Failed;

    [SerializeField]
    List<GameObject> sky_gameobjects;
    [SerializeField]
    float levelTime = 30.0f;

    private float moveAmount;

    private bool timedOut = false;

    private Light mainLight;

    // Start is called before the first frame update
    void Start ()
    {
        img = gameObject.GetComponent<Image> ();
        tmp = gameObject.GetComponentInChildren<TextMeshProUGUI> ();
        bar = GameObject.FindGameObjectWithTag ("AlertBar").GetComponent<AlertBar> ();
        bm = GameObject.Find ("ButtonManager").GetComponent<ButtonManager> ();
        player = GameObject.FindGameObjectWithTag ("Player");

        mainLight = GameObject.FindGameObjectWithTag ("MainLight").GetComponent<Light> ();
        mainAudio = GameObject.FindGameObjectWithTag ("MainAudio").GetComponent<AudioSource> ();
        footsteps = GameObject.FindGameObjectWithTag ("Player").GetComponent<AudioSource> ();

        moveAmount = sky_gameobjects[0].transform.position.y + 13.0f;

        StartCoroutine (Sunrise ());
    }

    // Update is called once per frame
    void Update ()
    {
        if (bar.AlertLevel >= 1 || timedOut)
        {
            StartCoroutine (FailState ());
            if (mainAudio != null)
            {
                if (mainAudio.clip != MusicPlayer.pubLose)
                {
                    mainAudio.loop = false;
                    mainAudio.clip = MusicPlayer.pubLose;
                    mainAudio.Play ();
                }
            }
        }

        //freeze player and tick down untill load main menu
        if (Failed)
        {
            player.SetActive (false);
            EndTimer -= Time.deltaTime;
        }

        if (EndTimer <= 0)
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

    private IEnumerator Sunrise ()
    {
        yield return new WaitForSeconds (levelTime);
        while (sky_gameobjects[0].transform.position.y <= moveAmount)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 pos = sky_gameobjects[i].transform.position;
                pos.y += 0.1f;
                sky_gameobjects[i].transform.position = pos;
            }
            if (mainLight.intensity <= 1.0f)
            {
                mainLight.intensity += 0.01f;
            }
            yield return new WaitForSeconds (0.1f);
        }

        timedOut = true;

    }
}