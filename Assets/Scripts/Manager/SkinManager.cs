using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public GameObject[] skinList;
    public GameObject[] buttonList;
    public Text[] textList;
    public GameObject left;
    public GameObject right;
    private int currSkin;
    public void SelectSkin()
    {
        int oldSkin = PlayerPrefs.GetInt("Skin", 0);
        buttonList[oldSkin].SetActive(true);
        buttonList[currSkin].SetActive(false);
        textList[oldSkin].color = Color.white;
        textList[currSkin].color = new Color(0.561f, 1f, 0.581f);
        PlayerPrefs.SetInt("Skin", currSkin);
    }
    public void Propogate(int dir)
    {
        skinList[currSkin].SetActive(false);
        currSkin += dir;
        skinList[currSkin].SetActive(true);
        CheckEnd();
    }
    private void CheckEnd()
    {
        left.SetActive(currSkin != 0);
        right.SetActive(currSkin != skinList.Length - 1);
    }
    private void Start()
    {
        currSkin = PlayerPrefs.GetInt("Skin", 0);
        skinList[currSkin].SetActive(true);
        buttonList[currSkin].SetActive(false);
        textList[currSkin].color = new Color(0.561f, 1f, 0.581f);
        CheckEnd();
    }
    public Animator transition;
    private float transitionPeriod = 0.5f;
    public void Back()
    {
        StartCoroutine(GoScene(0));
    }
    private IEnumerator GoScene(int sceneIndex)
    {
        transition.SetTrigger("StartTrans");
        yield return new WaitForSeconds(transitionPeriod);
        SceneManager.LoadScene(sceneIndex);
    }
}
