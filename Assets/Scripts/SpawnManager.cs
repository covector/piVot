using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int coinCount;
    public GameObject coin;
    public PhoneScreenScaler area;
    public float coinWidth;
    public void spawnCoin()
    {
        Vector2 topRight = area.getTopRight();
        float x = topRight.x/2 - coinWidth;
        float y = topRight.y/2 - coinWidth;
        float randX = Random.Range(-x, x);
        float randY = Random.Range(-y, y);
        Vector2 pos = new Vector2(randX, randY);
        Instantiate(coin, pos, Quaternion.identity);
    }

    public int enemyCount;
    public GameObject enemy;
    public float respawnRate;

    private void Start()
    {
        for (int i = 0; i < coinCount; i++)
        {
            spawnCoin();
        }
    }
}
