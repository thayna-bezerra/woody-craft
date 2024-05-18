using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource soundEffects;

    public static bool isSoundOn = true;

    private static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        backgroundMusic.mute = !isSoundOn;
        soundEffects.mute = !isSoundOn;
    }

    public void ToggleSound(bool isOn)
    {
        isSoundOn = isOn;
        backgroundMusic.mute = !isOn;
        soundEffects.mute = !isOn;
    }
    public void PlaySoundEffect(AudioClip clip)
    {
        if (isSoundOn && clip != null)
        {
            soundEffects.PlayOneShot(clip);
        }
    }
}
