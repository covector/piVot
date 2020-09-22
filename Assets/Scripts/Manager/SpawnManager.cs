﻿using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Coin
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
    #endregion

    #region Enemy
    public int enemyCount;
    public GameObject enemy;
    public float respawnCoolDown;
    public Vector3 spawnSite;
    private Quaternion orientation = Quaternion.Euler(new Vector3(0, 0, 225f));
    public void RequestRespawn()
    {
        StartCoroutine(Respawn());
    }
    private IEnumerator Respawn()
    {
        Debug.Log("respawning");
        yield return new WaitForSeconds(respawnCoolDown);
        Debug.Log("respawned");
        spawnEnemy();
    }
    public Vector3 getSpawn()
    {
        return spawnSite * area.getTopRight() / 2;
    }
    public void spawnEnemy()
    {
        Instantiate(enemy, getSpawn(), orientation, parentArea).transform.localScale = new Vector2(1f / 9f, 1f / 9f);
    }
    #endregion

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