using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Collect()
    {
        FindObjectOfType<GameManager>().AddPoint();
        FindObjectOfType<SpawnManager>().spawnCoin();
        Destroy(gameObject);
    }
}
