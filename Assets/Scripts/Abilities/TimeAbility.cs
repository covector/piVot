using UnityEngine;

public class TimeAbility : MonoBehaviour
{
    [SerializeField]
    private float fuel;
    public float fuelBurnRate;
    public float fuelGainRate;
    //public ParticleManager part;
    private float Ability()
    {
        int ranOut = fuel < 0 ? 1 : 0;
        fuel -= fuelBurnRate * Time.deltaTime * (1 - ranOut);
        float timeScale = fuel < 0 ? 1 : 0.2f;
        Time.timeScale = timeScale;
        //part.setActive(fuel >= 0);
        return fuel;
    }
    public KeyCode abilityHotkey;
    private void Update()
    {
        int limit = fuel < 1 ? 1 : 0;
        fuel += fuelGainRate * Time.deltaTime * limit;
        if (Input.GetKey(abilityHotkey)) { Ability(); }
        else
        {
            Time.timeScale = 1;
            //part.setActive(false);
        }
        bar.localScale = new Vector3(fuel, 1, 1);
    }
    public GameObject coolDownBar;
    public Transform bar;
    private void Start()
    {
        coolDownBar.SetActive(true);
    }
    private void SlowDown()
    {

    }
}
