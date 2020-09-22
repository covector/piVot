using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] skin;
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
