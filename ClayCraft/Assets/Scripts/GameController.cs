using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject panelHome;
    public GameObject panelCustomColor;

    public GameObject woodyAnimation;
    public GameObject woodpeckerAnimation;
    public GameObject woodModel;

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
    }

    public void BackInitialScreen(string name)
    {
        SceneManager.LoadScene(name);
    }


    public void GoToHome()
    {
        panelHome.SetActive(true);
        panelCustomColor.SetActive(false);

        woodyAnimation.SetActive(true);
        woodpeckerAnimation.SetActive(true);

        woodModel.SetActive(false);
    }

    public void StartGame(string name)
    {
        SceneManager.LoadScene(name);
    }

}
