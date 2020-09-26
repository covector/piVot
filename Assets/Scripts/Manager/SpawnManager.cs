using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Coin
    public int coinCount;
    public GameObject coin;
    public PhoneScreenScaler area;
    public Transform parentArea;
    public float coinWidth;
    public float deadAreaX;
    public float deadAreaY;
    public void spawnCoin()
    {
        float side = area.getTopRight()/2 - coinWidth;
        float randX;
        float randY;
        do
        {
            randX = Random.Range(-side, side);
            randY = Random.Range(-side, side);
        } while ((randX > deadAreaX * side) & (randY > deadAreaY * side));
        Vector2 pos = new Vector2(randX, randY);
        Instantiate(coin, pos, Quaternion.identity, parentArea).transform.localScale = new Vector2(1f / 9f, 1f / 9f);
        FindObjectOfType<ParticleManager>().coinSpawn(pos);
    }
    #endregion

    #region Enemy
    public int enemyCount;
    public GameObject enemy;
    public float respawnCoolDown;
    public Vector3 spawnSite;
    public float minSpeed;
    public float maxSpeed;
    private Quaternion orientation = Quaternion.Euler(new Vector3(0, 0, 225f));
    public void RequestRespawn(float speed)
    {
        StartCoroutine(Respawn(speed));
    }
    private IEnumerator Respawn(float speed)
    {
        //Debug.Log("respawning");
        yield return new WaitForSeconds(respawnCoolDown);
        //Debug.Log("respawned");
        spawnEnemy(speed);
    }
    public Vector3 getSpawn()
    {
        return spawnSite * area.getTopRight() / 2;
    }
    public void spawnEnemy(float speed)
    {
        GameObject enemySpawn = Instantiate(enemy, getSpawn(), orientation, parentArea);
        enemySpawn.GetComponent<Enemy>().speed = speed;
    }
    #endregion

    private void Start()
    {
        for (int i = 0; i < coinCount; i++)
        {
            spawnCoin();
        }
        if (enemyCount > 1)
        {
            for (float i = minSpeed; i <= maxSpeed; i += (maxSpeed - minSpeed) / (enemyCount - 1))
            {
                spawnEnemy(i);
            }
        }
        else
        {
            spawnEnemy(minSpeed);
        }
    }
}
