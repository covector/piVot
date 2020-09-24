using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] skinObj;
    public enum skin { Default, Double, Gun, Rocket, Dual};
    public skin skinChoice;
    public int skinIndex;
    private void Start()
    {
        skinIndex = PlayerPrefs.GetInt("Skin", (int)skinChoice);
        getSkin().SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.Alpha1)) { PlayerPrefs.SetInt("Skin", 0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { PlayerPrefs.SetInt("Skin", 1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { PlayerPrefs.SetInt("Skin", 2); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { PlayerPrefs.SetInt("Skin", 3); }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { PlayerPrefs.SetInt("Skin", 4); }
    }
}
