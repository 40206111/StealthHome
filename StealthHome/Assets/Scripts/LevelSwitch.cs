using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    AudioSource mainAudio;

    private GameObject player;

    private void Start ()
    {
        mainAudio = GameObject.FindGameObjectWithTag ("MainAudio").GetComponent<AudioSource> ();
        player = GameObject.FindGameObjectWithTag("Player");
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
        GameObject.FindGameObjectWithTag("AlertBar").GetComponent<AlertBar>().dont_track = true;
        StartCoroutine(Chill());
        yield return new WaitForSeconds (MusicPlayer.levelWin.length);
        int currentIndex = SceneManager.GetActiveScene ().buildIndex;
        int nextIndex = currentIndex + 1;
        SceneManager.LoadScene (nextIndex);
        yield return null;
    }

    IEnumerator Chill()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        player.GetComponent<Player_controls>().disable = true;
        yield return new WaitForEndOfFrame();
        player.GetComponent<Animator>().SetBool("Walk", false);

        yield return new WaitForSeconds(1.0f);

        player.GetComponent<Animator>().SetBool("Walk", true);

        float move = player.transform.position.y + 0.4f;
        while (player.transform.position.y <= move)
        {
            Vector2 pos = player.transform.position;
            pos.y += 0.1f;
            pos.x += 0.1f;

            player.transform.position = pos;
            yield return new WaitForSeconds(0.1f);
        }
        player.GetComponent<Animator>().SetBool("Walk", false);

        yield return new WaitForSeconds(0.7f);

        player.GetComponent<Animator>().SetBool("Crouch", true);
    }
}