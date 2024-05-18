using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject panelHome;
    public GameObject panelCustomColor;

    public GameObject woodyAnimation;
    public GameObject woodpeckerAnimation;
    public GameObject woodModel;

    public AudioClip buttonClickSound;

    public void ReloadScene()
    {
        PlaySoundEffect(buttonClickSound);

        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void GoToCustomColor()
    {
        PlaySoundEffect(buttonClickSound);

        panelHome.SetActive(false);
        panelCustomColor.SetActive(true);
        woodyAnimation.SetActive(false);
        woodpeckerAnimation.SetActive(false);
        woodModel.SetActive(true);
    }

    public void GoHome()
    {
        PlaySoundEffect(buttonClickSound);

        panelCustomColor.SetActive(false);
        panelHome.SetActive(true);
        woodyAnimation.SetActive(true);
        woodpeckerAnimation.SetActive(true);
        woodModel.SetActive(false);
    }

    public void BackInitialScreen(string name)
    {
        PlaySoundEffect(buttonClickSound);
        SceneManager.LoadScene(name);
    }

    public void StartGame(string name)
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
