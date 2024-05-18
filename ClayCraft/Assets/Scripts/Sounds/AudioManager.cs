using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    //public AudioSource soundEffects;

    public static bool isSoundOn = true;

    private static AudioManager instance;

    void Awake()
    {
        // Assegura que o AudioManager persiste entre as cenas
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Configura o estado inicial do som
        backgroundMusic.mute = !isSoundOn;
        //soundEffects.mute = !isSoundOn;
    }

    public void ToggleSound(bool isOn)
    {
        isSoundOn = isOn;
        backgroundMusic.mute = !isOn;
        //soundEffects.mute = !isOn;
    }
}
