using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public GameObject[] skinList;
    public Button skinButton;
    public Text buttonText;
    public Image[] imageList;
    public Text skinText;
    public string[] skinName;
    public GameObject left;
    public GameObject right;
    public int[] price;
    private int currSkin;
    private int selSkin;
    public bool[] possess;
    private int state;
    public void ButtonClick()
    {
        switch (state)
        {
            case 1:
                selSkin = currSkin;
                PlayerPrefs.SetInt("Skin", selSkin);
                break;
            case 2:
                Buy();
                break;
        }
        UpdateState();
    }
    public void Propogate(int dir)
    {
        skinList[currSkin].SetActive(false);
        currSkin += dir;
        skinList[currSkin].SetActive(true);
        CheckEnd();
        UpdateState();
    }
    private void CheckEnd()
    {
        left.SetActive(currSkin != 0);
        right.SetActive(currSkin != skinList.Length - 1);
    }
    public Color selectedColor;
    public Color restColor;
    public Color disabledColor;
    private void UpdateState()
    {
        if (possess[currSkin])
        {
            skinText.text = skinName[currSkin];
            imageList[currSkin].color = Color.white;
            if (currSkin == selSkin)
            {
                skinText.color = selectedColor;
                skinButton.interactable = false;
                buttonText.text = "Selected";
                state = 0;
            }
            else
            {
                skinText.color = restColor;
                skinButton.interactable = true;
                buttonText.text = "Select";
                state = 1;
            }
        }
        else
        {
            skinText.text = "???";
            imageList[currSkin].color = Color.black;
            skinText.color = disabledColor;
            skinButton.interactable = true;
            buttonText.text = "$" + price[currSkin].ToString();
            state = 2;
        }
    }
    private void Possession(bool firstTime = false)
    {
        if (firstTime)
        {
            string boughtList = PlayerPrefs.GetString("Bought");
            if (boughtList == string.Empty) { boughtList = "1000"; }
            for (int i = 0; i < boughtList.Length; i++)
            {
                if (boughtList[i] == '1')
                {
                    possess[i] = true;
                }
            }
        }
        else
        {
            string concat = string.Empty;
            for (int i = 0; i < possess.Length; i++)
            {
                concat += possess[i] ? "1" : "0";
            }
            PlayerPrefs.SetString("Bought", concat);
        }
    }
    private void Buy()
    {
        if (FindObjectOfType<MoneyManager>().Buy(price[currSkin]))
        {
            possess[currSkin] = true;
            Possession();
        }
    }
    private void Start()
    {
        selSkin = PlayerPrefs.GetInt("Skin", 0);
        currSkin = selSkin;
        skinList[currSkin].SetActive(true);
        Possession(true);
        CheckEnd();
        UpdateState();
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
    public void Reset()
    {
        FindObjectOfType<MoneyManager>().Reset();
        PlayerPrefs.SetString("Bought", "1000");
        PlayerPrefs.SetInt("Skin", 0);
        SceneManager.LoadScene(2);
    }
}