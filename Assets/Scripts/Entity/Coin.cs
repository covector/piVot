using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Collect()
    {
        FindObjectOfType<CameraShake>().InitShake(0.5f, 0.1f);
        FindObjectOfType<ParticleManager>().coinCollect(gameObject.transform.position);
        FindObjectOfType<GameManager>().AddPoint();
        FindObjectOfType<SpawnManager>().spawnCoin();
        Destroy(gameObject);
    }
}
