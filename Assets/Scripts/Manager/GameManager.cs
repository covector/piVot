using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] skinObj;
    public enum skin { Default, Double, Gun, Rocket, Dual };
    public skin skinChoice;
    public int skinIndex;
    private void Start()
    {
        skinIndex = PlayerPrefs.GetInt("Skin", 0);
        getSkin().SetActive(true);
        string pivotHotkey = PlayerPrefs.GetString("ChangePivot", "X");
        getSkin().GetComponent<Pivot>().pivotHotkey = (KeyCode)Enum.Parse(typeof(KeyCode), pivotHotkey);
        string abilityHotkey = PlayerPrefs.GetString("UseAbility", "Z");
        KeyCode abilityHotkeyCode = (KeyCode)Enum.Parse(typeof(KeyCode), abilityHotkey);
        switch (skinIndex)
        {
            case 1:
                FindObjectOfType<DoubleAbility>().abilityHotkey = abilityHotkeyCode;
                break;
            case 2:
                FindObjectOfType<GunAbility>().abilityHotkey = abilityHotkeyCode;
                break;
            case 3:
                FindObjectOfType<RocketAbility>().abilityHotkey = abilityHotkeyCode;
                break;
            case 4:
                FindObjectOfType<DualAbility>().abilityHotkey = abilityHotkeyCode;
                break;
        }


    }
    public GameObject getSkin()
    {
        return skinObj[skinIndex];
    }
    public int points;
    public Text pointsText;
    public void AddPoint()
    {
        points++;
        pointsText.text = points.ToString();
    }
    public GameObject overScreen;
    public void GameOver()
    {
        skinObj[skinIndex].SetActive(false);
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GameOver();
        }
        overScreen.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene(1); }
    }
}
