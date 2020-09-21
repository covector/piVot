﻿using UnityEngine;

public class Player : MonoBehaviour
{
    public Pivot piv;
    public int invul;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        WallDetection(collider);
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        WallDetection(collider);
    }
    private void WallDetection(Collider2D collider)
    {
        string tag = collider.gameObject.tag;
        int wall = (tag == "Wall0") ? 0 : (tag == "Wall1") ? 1 : (tag == "Wall2") ? 2 : (tag == "Wall3") ? 3 : -1;
        if (wall >= 0)
        {
            piv.changeDir(invul, wall);
        }
    }
}
