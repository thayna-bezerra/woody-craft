using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject panelHome;
    public GameObject panelCustomColor;
    //public GameObject panelGame;
    public GameObject woodyAnimation;
    public GameObject woodpeckerAnimation;
    public GameObject woodModel;
    //public GameObject knife;

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void GoToCustomColor()
    {
        panelHome.SetActive(false);
        panelCustomColor.SetActive(true);
        woodyAnimation.SetActive(false);
        woodpeckerAnimation.SetActive(false);
        woodModel.SetActive(true);

        //SoundController.sounds.click.Play();
    }

    public void GoToHome()
    {
        panelHome.SetActive(true);
        panelCustomColor.SetActive(false);
        //panelGame.SetActive(false);

        woodyAnimation.SetActive(true);
        woodpeckerAnimation.SetActive(true);

        woodModel.SetActive(false);
        //knife.SetActive(false);

        //SoundController.sounds.click.Play();
    }
    /*public void StartGame()
    {
        SceneManager.LoadScene(Game);
        //panelCustomColor.SetActive(false);
        //knife.SetActive(true);
        //panelGame.SetActive(true);

        //SoundController.sounds.click.Play();
    }*/
    public void StartGame(string name)
    {
        SceneManager.LoadScene(name);
    }

}
