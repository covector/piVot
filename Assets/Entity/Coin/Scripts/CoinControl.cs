using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public Constants constants;
    public GameObject coin;
    public GameObject spawnParticle;
    public GameObject collectParticle;
    public Transform parentArea;
    float areaRadius;
    float coinDiameter;
    Vector2 restrictAreaMin;
    Vector2 restrictAreaMax;

    void Start()
    {
        coinDiameter = constants.coinDiameter;
        areaRadius = constants.areaRadius;
        for (int i = 0; i < constants.coinCount; i++)
        {
            SpawnCoin();
        }
    }

    public void SpawnCoin()
    {
        float side = areaRadius - coinDiameter;
        float randX;
        float randY;
        do
        {
            randX = Random.Range(-side, side);
            randY = Random.Range(-side, side);
        } while (randX > restrictAreaMin.x && randY > restrictAreaMin.y && randX < restrictAreaMax.x && randY < restrictAreaMax.y);
        Vector2 pos = new Vector2(randX, randY);
        Instantiate(coin, pos, Quaternion.identity, parentArea);
        Instantiate(spawnParticle, pos, Quaternion.identity, parentArea);
    }

    public void CollectCoin(Vector2 pos)
    {
        Instantiate(collectParticle, pos, Quaternion.identity, parentArea);
        FindObjectOfType<CameraShake>().InitShake(0.5f, 0.1f);
        SpawnCoin();
    }
}
