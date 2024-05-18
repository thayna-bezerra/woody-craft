using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioClip buttonClickSound;

    public void ChangeScene(string name)
    {
        PlaySoundEffect(buttonClickSound);
        SceneManager.LoadScene(name);
    }

    public void PlaySoundEffect(AudioClip sound)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.PlaySoundEffect(sound);
        }
    }
}
