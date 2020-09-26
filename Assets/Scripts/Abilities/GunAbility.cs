using UnityEngine;

public class GunAbility : MonoBehaviour
{
    public Pivot piv;
    public GameObject bullet;
    private float coolDown;
    public GameObject area;
    public ParticleManager part;
    public GameObject bulletParticle;
    private bool Ability()
    {
        if (coolDown <= 0)
        {
            GameObject bulletSpawn = Instantiate(bullet, piv.getLoc(1), gameObject.transform.rotation, area.transform);
            GameObject bulletPart = Instantiate(bulletParticle, piv.getLoc(1), Quaternion.identity, area.transform);
            bulletSpawn.GetComponent<Bullet>().SetParticle(bulletPart);
            part.MuzzleFlash();
            coolDown = 1f;
            return true;
        }
        return false;
    }
    public GameObject coolDownBar;
    public Transform bar;
    public KeyCode abilityHotkey;
    private void Update()
    {
        int limit = coolDown > 0 ? 1 : 0;
        coolDownBar.SetActive(coolDown > 0);
        coolDown -= Time.deltaTime * limit / 1f;
        if (Input.GetKeyDown(abilityHotkey)) { Ability(); }
        bar.localScale = new Vector3(coolDown, 1, 1);
    }
}
