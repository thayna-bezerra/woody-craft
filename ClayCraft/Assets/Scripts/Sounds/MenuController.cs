using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private bool isSoundOn;

    void Start()
    {
        // Inicializa o estado do som com o estado armazenado no AudioManager
        isSoundOn = AudioManager.isSoundOn;
        UpdateButtonImage();

        // Adiciona um listener para o botão para chamar a função ToggleSound quando clicado
        soundButton.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        // Encontra o AudioManager e chama a função ToggleSound
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
            soundButton.image.sprite = soundOnSprite;
        }
        else
        {
            soundButton.image.sprite = soundOffSprite;
        }
    }
}
