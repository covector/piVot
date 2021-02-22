using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerBehaviour behaviour;
    public bool head;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "Coin":
                CoinDetection(collider);
                break;
            case "Enemy":
                EnemyDetection(collider);
                break;
            case "Wall0":
                WallDetection(0);
                break;
            case "Wall1":
                WallDetection(1);
                break;
            case "Wall2":
                WallDetection(2);
                break;
            case "Wall3":
                WallDetection(3);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "Coin":
                CoinDetection(collider);
                break;
            case "Wall0":
                WallDetection(0);
                break;
            case "Wall1":
                WallDetection(1);
                break;
            case "Wall2":
                WallDetection(2);
                break;
            case "Wall3":
                WallDetection(3);
                break;
        }
    }

    private void WallDetection(int wallInd)
    {
        behaviour.Reflect(head, wallInd);
    }

    private void CoinDetection(Collider2D collider)
    {
        if (head)
        {
            collider.GetComponent<CoinBehaviour>().Collect();
        }
    }

    private void EnemyDetection(Collider2D collider)
    {
        if (head)
        {
            //collider.GetComponent<EnemyBehaviour>().Killed();
        }
        else
        {
            behaviour.Killed();
        }
    }
}
