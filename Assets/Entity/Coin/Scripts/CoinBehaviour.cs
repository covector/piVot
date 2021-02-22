using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public void Collect()
    {
        FindObjectOfType<CoinControl>().CollectCoin(transform.position);
        Destroy(gameObject);
    }
}
