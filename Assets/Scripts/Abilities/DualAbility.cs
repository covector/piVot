using UnityEngine;

public class DualAbility : MonoBehaviour
{
    public Pivot piv;
    public Player vul;
    public Player invul;
    private float coolDown;
    private bool Ability()
    {
        if (coolDown <= 0)
        {
            vul.invul = 1 - vul.invul;
            invul.invul = 1 - invul.invul;
            coolDown = 1f;
            return true;
        }
        return false;
    }
    private void Update()
    {
        int limit = coolDown > 0 ? 1 : 0;
        coolDown -= Time.deltaTime * limit;
        if (Input.GetKeyDown(KeyCode.Z)) { Ability(); }
    }
}
