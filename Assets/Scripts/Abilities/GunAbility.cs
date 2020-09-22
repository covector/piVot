﻿using UnityEngine;

public class GunAbility : MonoBehaviour
{
    public Pivot piv;
    public GameObject bullet;
    private float coolDown;
    private bool Ability()
    {
        if (coolDown <= 0)
        {
            Instantiate(bullet, piv.getLoc(1), gameObject.transform.rotation);
            coolDown = 1f;
            return true;
        }
        return false;
    }
    private void Update()
    {
        int limit = coolDown <= 0 ? 1 : 0;
        coolDown -= Time.deltaTime * limit;

    }
}
