using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Background Music")]
    public AudioClip backgroundMusic;

    [Header("Sound Effects")]
    public AudioClip flapSound;
    public AudioClip hitSound;
    public AudioClip scoreSound;
    public AudioClip gameOverSound;
    public AudioClip buttonSound;

    private bool hitPlayed = false;
    private bool gameOverPlayed = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        if (musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.playOnAwake = false;
        }

        if (sfxSource != null)
        {
            sfxSource.playOnAwake = false;
        }

        StopMusic();
    }

    public void PlayMusic()
    {
        if (musicSource == null || backgroundMusic == null)
            return;

        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }

    public void PlayFlap()
    {
        PlaySound(flapSound);
    }

    public void PlayScore()
    {
        PlaySound(scoreSound);
    }

    public void PlayHit()
    {
        if (hitPlayed) return;

        hitPlayed = true;
        PlaySound(hitSound);
    }

    public void PlayGameOver()
    {
        if (gameOverPlayed) return;

        gameOverPlayed = true;
        PlaySound(gameOverSound);
    }

    public void PlayButton()
    {
        PlaySound(buttonSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
