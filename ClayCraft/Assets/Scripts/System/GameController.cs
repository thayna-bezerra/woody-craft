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
        panelCustomColor.SetActive(false);
        panelHome.SetActive(true);

        woodyAnimation.SetActive(true);
        woodpeckerAnimation.SetActive(true);

        woodModel.SetActive(false);
        Debug.Log("olaaa");
    }

    public void StartGame(string name)
    {
        SceneManager.LoadScene(name);
    }

}
