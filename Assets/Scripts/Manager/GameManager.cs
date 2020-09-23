using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] skinObj;
    public enum skin { Default, Double, Gun, Rocket, Dual};
    public skin skinChoice;
    public int skinIndex;
    private void Start()
    {
        skinIndex = (int)skinChoice;
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
    public void GameOver()
    {

    }
}
