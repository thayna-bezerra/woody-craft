using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioClip buttonClickSound;

    public GameObject panelGame;
    public GameObject panelDone;
    public GameObject woodpecker;

    public GameObject wood;
    public Vector3 targetPosition = new Vector3(0, 1.26f, 0);
    public Vector3 targetRotation = new Vector3(-90, 0, 0);
    public float duration = 2.0f; 

    public void ChangeScene(string name)
    {
        PlaySoundEffect(buttonClickSound);
        SceneManager.LoadScene(name);
    }

    public void GoDonePanel()
    {
        PlaySoundEffect(buttonClickSound);

        panelDone.SetActive(true);
        panelGame.SetActive(false);
        woodpecker.SetActive(false);

        if (wood != null)
        {
            GameObject modelInstance = Instantiate(wood, transform.position, Quaternion.identity);
            wood.SetActive(false);
            StartCoroutine(AnimateModel(modelInstance, targetPosition, targetRotation, duration));
        }
    }
    private IEnumerator AnimateModel(GameObject model, Vector3 endPosition, Vector3 endRotation, float animationDuration)
    {
        Vector3 startPosition = model.transform.position;
        Quaternion startRotation = model.transform.rotation;
        Quaternion endQuaternion = Quaternion.Euler(endRotation);

        float elapsedTime = 0;

        while (elapsedTime < animationDuration)
        {
            model.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / animationDuration);
            model.transform.rotation = Quaternion.Lerp(startRotation, endQuaternion, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        model.transform.position = endPosition;
        model.transform.rotation = endQuaternion;
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
