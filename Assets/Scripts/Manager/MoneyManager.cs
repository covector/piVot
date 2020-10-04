using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int coinStorage;
    private int coinBuffer;
    public void SaveProgress()
    {
        coinStorage += coinBuffer;
        coinBuffer = 0;
        PlayerPrefs.SetInt("Coins", coinStorage);
    }
    public void AddCoin()
    {
        coinBuffer++;
        coinDisplay.text = GetCoin().ToString();
    }
    public bool Buy(int price)
    {
        if (coinStorage < price)
        {
            return false;
        }
        coinBuffer -= price;
        SaveProgress();
        coinDisplay.text = GetCoin().ToString();
        return true;
    }
    public int GetCoin()
    {
        return coinStorage + coinBuffer;
    }
    public Text coinDisplay;
    private void Start()
    {
        coinStorage = PlayerPrefs.GetInt("Coins");
        coinBuffer = 0;
        coinDisplay.text = GetCoin().ToString();
    }
    public void Reset()
    {
        coinStorage = 0;
        coinBuffer = 0;
        SaveProgress();
    }
}
