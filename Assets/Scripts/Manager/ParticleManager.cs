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
    public ParticleSystem[] kineticParticles = new ParticleSystem[2];
    private int initSide = 0;
    public void pivotChange()
    {
        initSide = 1 - initSide;
    }
    public void setActive(bool active)
    {
        var emit0 = kineticParticles[initSide].emission;
        emit0.enabled = active;
        var emit1 = kineticParticles[1 - initSide].emission;
        emit1.enabled = false;
    }
    public Transform dualParticle;
    public GameObject dualSmoke;
    public void rotatePart(Vector3 pos, Quaternion rot)
    {
        dualParticle.eulerAngles += new Vector3(0, 0, 180f);
        dualParticle.localPosition *= -1f;
        Instantiate(dualSmoke, pos, rot, parent);
    }
    public GameObject muzzleFlashPart;
    public void MuzzleFlash()
    {
        muzzleFlashPart.SetActive(true);
    }
}
