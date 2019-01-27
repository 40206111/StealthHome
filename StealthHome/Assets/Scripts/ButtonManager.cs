using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    AudioSource a;

    private void Start ()
    {
        a = gameObject.GetComponent<AudioSource> ();
    }

    public void ExitGame ()
    {
        a.Play ();
        Application.Quit ();
    }

    public void StartMenu ()
    {
        a.Play ();
        SceneManager.LoadScene ("StartScreen");
    }

    public void Begin ()
    {
        a.Play ();
        SceneManager.LoadScene ("Level1");
    }
}