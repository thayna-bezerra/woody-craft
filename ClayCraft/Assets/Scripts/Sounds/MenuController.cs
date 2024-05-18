using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject panelHome;
    public GameObject panelCustomColor;

    public GameObject woodyAnimation;
    public GameObject woodpeckerAnimation;
    public GameObject woodModel;

    public Button soundButton;
    public Sprite soundOn;
    public Sprite soundOff;

    public AudioClip buttonClickSound;
    private bool isSoundOn;

    void Start()
    {
        isSoundOn = AudioManager.isSoundOn;
        UpdateButtonImage();

        soundButton.onClick.AddListener(ToggleSound);
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

    public void ChangeScene(string name)
    {
        PlaySoundEffect(buttonClickSound);
        SceneManager.LoadScene(name);
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

    public void PlaySoundEffect(AudioClip sound)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.PlaySoundEffect(sound);
        }
    }

    void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.ToggleSound(isSoundOn);
        }

        UpdateButtonImage();
    }

    void UpdateButtonImage()
    {
        if (isSoundOn)
        {
            soundButton.image.sprite = soundOn;
        }
        else
        {
            soundButton.image.sprite = soundOff;
        }
    }
}
