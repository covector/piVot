using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int coinCount;
    public GameObject coin;
    public PhoneScreenScaler area;
    public Transform parentArea;
    public float coinWidth;
    public void spawnCoin()
    {
        float side = area.getTopRight()/2 - coinWidth;
        float randX = Random.Range(-side, side);
        float randY = Random.Range(-side, side);
        Vector2 pos = new Vector2(randX, randY);
        Instantiate(coin, pos, Quaternion.identity, parentArea).transform.localScale = new Vector2(1f / 9f, 1f / 9f);
    }

    public int enemyCount;
    public GameObject enemy;
    public float respawnCoolDown;
    public Vector2 spawnSite;
    private Quaternion orientation = Quaternion.Euler(new Vector3(0, 0, 225f));
    public IEnumerator Respawn()
    {
        Debug.Log("respawning");
        yield return new WaitForSeconds(respawnCoolDown);
        Debug.Log("respawned");
        spawnEnemy();
    }
    public void spawnEnemy()
    {
        Instantiate(enemy, spawnSite * area.getTopRight() / 2, orientation, parentArea).transform.localScale = new Vector2(1f / 9f, 1f / 9f);
    }

    private void Start()
    {
        for (int i = 0; i < coinCount; i++)
        {
            spawnCoin();
        }
        for (int i = 0; i < enemyCount; i++)
        {
            spawnEnemy();
        }
    }
}
