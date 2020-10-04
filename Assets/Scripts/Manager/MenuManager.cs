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
    private IEnumerator GoScene(int sceneIndex)
    {
        transition.SetTrigger("StartTrans");
        yield return new WaitForSeconds(transitionPeriod);
        SceneManager.LoadScene(sceneIndex);
    }
    private IEnumerator QuitGameCoroutine()
    {
        transition.SetTrigger("StartTrans");
        yield return new WaitForSeconds(transitionPeriod);
        Application.Quit();
    }
    #region Shop Bypass
    public int[] safe =  new int[6];
    private KeyCode[] key = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6 };
    private void Update()
    {
        for (int i = 0; i < safe.Length; i++)
        {
            safe[i] += Input.GetKeyDown(key[i]) ? 1 : 0;
            if (safe[i] >= 3)
            {
                PlayerPrefs.SetInt("Skin", i);
                safe[i] = 0;
            }
        }
    }
    #endregion
}
