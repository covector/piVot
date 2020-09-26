using System.Linq.Expressions;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public Transform parent;
    public GameObject enemyParticle;
    public GameObject coinParticle;
    public GameObject smokeParticle;
    public void enemyDeath(Vector3 pos)
    {
        Instantiate(enemyParticle, pos, Quaternion.identity, parent);
    }
    public void coinCollect(Vector3 pos)
    {
        Instantiate(coinParticle, pos, Quaternion.identity, parent);
    }
    public void coinSpawn(Vector3 pos)
    {
        Instantiate(smokeParticle, pos, Quaternion.identity, parent);
    }
}
