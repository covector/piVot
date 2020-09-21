using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Collect()
    {
        FindObjectOfType<SpawnManager>().spawnCoin();
        Destroy(gameObject);
    }
}
