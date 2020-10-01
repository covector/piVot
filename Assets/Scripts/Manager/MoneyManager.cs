using UnityEngine;
using SecPlayerPrefs;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    private int coinStorage;
    private int coinBuffer;
    public void SaveProgress()
    {
        coinStorage += coinBuffer;
        coinBuffer = 0;
        SecurePlayerPrefs.SetInt("Coins", coinStorage);
    }
    public void AddCoin()
    {
        coinBuffer++;
        coinDisplay.text = GetCoin().ToString();
    }
    public int GetCoin()
    {
        return coinStorage + coinBuffer;
    }
    public Text coinDisplay;
    private void Start()
    {
        coinStorage = SecurePlayerPrefs.GetInt("Coins");
        coinBuffer = 0;
        coinDisplay.text = GetCoin().ToString();
    }
}
