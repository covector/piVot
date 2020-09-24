using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator transition;
    private float transitionPeriod = 0.5f;
    public void StartGame()
    {
        StartCoroutine(GoScene(1));
    }
    public void QuitGame()
    {
        StartCoroutine(QuitGameCoroutine());
    }
    public void GoSkin()
    {
        StartCoroutine(GoScene(2));
    }
    public void GoOption()
    {
        StartCoroutine(GoScene(3));
    }
    public IEnumerator GoScene(int sceneIndex)
    {
        transition.SetTrigger("StartTrans");
        yield return new WaitForSeconds(transitionPeriod);
        SceneManager.LoadScene(sceneIndex);
    }
    public IEnumerator QuitGameCoroutine()
    {
        transition.SetTrigger("StartTrans");
        yield return new WaitForSeconds(transitionPeriod);
        Application.Quit();
    }
}
