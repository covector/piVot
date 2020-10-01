using System;
using System.Collections;
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
        estimatedFPS = 1f/Time.deltaTime;
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
        FindObjectOfType<MoneyManager>().SaveProgress();
    }
    public Animator transition;
    private float transitionPeriod = 0.5f;
    public Image backTrans;
    public float estimatedFPS;
    public void Back()
    {
        transition.enabled = false;
        StartCoroutine(GoScene(0));
    }
    private IEnumerator GoScene(int sceneIndex)
    {
        for (float i = 0f; i <= 1f; i += 1f / (estimatedFPS * transitionPeriod))
        {
            backTrans.color = new Color(0f, 0f, 0f, i);
            yield return null;
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }
    public float pauseCoolDown = 1f;
    public GameObject pauseScreen;
    public void TogglePause()
    {
        int allowPause = pauseCoolDown >= 1f ? 1 : 0;
        pauseCoolDown *= Time.timeScale;
        Time.timeScale = 1 - Time.timeScale * allowPause;
        pauseScreen.SetActive(Time.timeScale == 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { Time.timeScale = 1f; SceneManager.LoadScene(1); }
        int clip = pauseCoolDown > 1f ? 0 : 1;
        pauseCoolDown += Time.deltaTime * clip;
        if (Input.GetKeyDown(KeyCode.Escape)) { TogglePause(); }
    }
}
