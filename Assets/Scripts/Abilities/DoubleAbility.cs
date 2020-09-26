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
    public GameObject coolDownBar;
    public Transform bar;
    public KeyCode abilityHotkey;
    private void Update()
    {
        int limit = coolDown > 0 ? 1 : 0;
        coolDownBar.SetActive(coolDown > 0);
        coolDown -= Time.deltaTime * limit / 3f;
        if (Input.GetKeyDown(abilityHotkey)) { Ability(); }
        bar.localScale = new Vector3(coolDown, 1, 1);
    }
}
