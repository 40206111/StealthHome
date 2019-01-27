using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other)
    {
        int currentIndex = SceneManager.GetActiveScene ().buildIndex;
        int nextIndex = currentIndex + 1;
        SceneManager.LoadScene (nextIndex);
    }

    // Update is called once per frame
    void Update ()
    {

    }
}