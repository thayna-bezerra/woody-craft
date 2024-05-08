using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject panelHome;
    public GameObject panelCustomColor;
    public GameObject panelGame;
    public GameObject woodHomeAnimation;
    public GameObject woodModel;
    public GameObject knife;

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void GoToCustomColor()
    {
        panelHome.SetActive(false);
        panelCustomColor.SetActive(true);
        woodHomeAnimation.SetActive(false);
        woodModel.SetActive(true);

        //SoundController.sounds.click.Play();
    }

    public void GoToHome()
    {
        panelHome.SetActive(true);
        panelCustomColor.SetActive(false);
        panelGame.SetActive(false);

        woodHomeAnimation.SetActive(true);
        woodModel.SetActive(false);
        knife.SetActive(false);

        //SoundController.sounds.click.Play();
    }
    public void StartGame()
    {
        panelCustomColor.SetActive(false);
        knife.SetActive(true);
        panelGame.SetActive(true);

        //SoundController.sounds.click.Play();
    }

}
