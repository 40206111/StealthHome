using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    AudioSource mainAudio;

    private void Start ()
    {
        mainAudio = GameObject.FindGameObjectWithTag ("MainAudio").GetComponent<AudioSource> ();

    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        mainAudio.loop = false;
        mainAudio.clip = MusicPlayer.levelWin;
        mainAudio.Play ();
        StartCoroutine ("NextLevel");
    }

    IEnumerator NextLevel ()
    {
        yield return new WaitForSeconds (MusicPlayer.levelWin.length);
        int currentIndex = SceneManager.GetActiveScene ().buildIndex;
        int nextIndex = currentIndex + 1;
        SceneManager.LoadScene (nextIndex);
        yield return null;
    }
}