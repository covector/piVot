using UnityEngine;

public class Player : MonoBehaviour
{
    public Pivot piv;
    public int invul;
    private int tip;
    private void Start()
    {
        tip = invul;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        WallDetection(collider);
        CoinDetection(collider);
        EnemyDetection(collider);
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
            piv.changeDir(tip, wall);
        }
    }
    private void CoinDetection(Collider2D collider)
    {
        if (collider.gameObject.tag == "Coin" & invul == 1)
        {
            collider.gameObject.GetComponent<Coin>().Collect();
        }
    }
    private void EnemyDetection(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (invul == 1)
            {
                collider.gameObject.GetComponent<Enemy>().Kill();
            }
            if (invul == 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        FindObjectOfType<GameManager>().GameOver();
    }
}
