using UnityEngine;

public class DoubleAbility : MonoBehaviour
{
    public Pivot piv;
    private float coolDown;
    private bool Ability()
    {
        if (coolDown <= 0)
        {
            piv.changeDir();
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
