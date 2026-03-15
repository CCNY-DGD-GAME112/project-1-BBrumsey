using UnityEngine;
/*
Music Manager:
This script controls the background music for the game. It uses a singleton so only one music manager exists and the music continues between scnes
*/
public class MusicManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public static MusicManager Instance;

    public AudioSource musicSource;
    public AudioClip musicClip;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PlayMusic(); 
    }

    public void PlayMusic()
    {
        if (musicSource != null && musicClip != null)
        {
            {
                musicSource.clip = musicClip;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
    }
            public void StopMusic()
    {
        if (musicSource != null)
            musicSource.Stop();
    }
}

   
