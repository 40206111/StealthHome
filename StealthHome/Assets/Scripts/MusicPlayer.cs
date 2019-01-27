using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    private AudioSource music;

    [SerializeField]
    private AudioClip intro;
    [SerializeField]
    private AudioClip gameMusic;
    [SerializeField]
    private AudioClip lose;

    public static AudioClip pubLose;


    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelLoaded;
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }

        music = GetComponent<AudioSource>();
        pubLose = lose;
    }

    void LevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "StartScreen")
        {
            Debug.Log(scene.name);
            music.loop = true;
            music.clip = gameMusic;
            music.PlayDelayed(0.5f);
        }
    }
}
