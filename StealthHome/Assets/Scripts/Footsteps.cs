using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sounds; 

    private AudioSource sourceA;

    void Start()
    {
        sourceA = GetComponent<AudioSource>();
    }

    public void WalkSound()
    {
        if (!sourceA.isPlaying)
        {
            AudioClip next = sounds[Random.Range(0, sounds.Length)];
            sourceA.clip = next;
            sourceA.Play();
        }
    }
}
