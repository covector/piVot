using UnityEngine;

public class RocketAbility : MonoBehaviour
{
    public Pivot piv;
    [SerializeField]
    private float fuel;
    public float fuelBurnRate;
    public float fuelGainRate;
    private float Ability()
    {
        int ranOut = fuel < 0 ? 1 : 0;
        fuel -= fuelBurnRate * Time.deltaTime * (1-ranOut);
        ranOut = fuel < 0 ? 1 : 0;
        piv.accelerate(ranOut);
        return fuel;
    }
    private void Update()
    {
        int limit = fuel < 1 ? 1 : 0;
        fuel += fuelGainRate * Time.deltaTime * limit;
        if (Input.GetKey(KeyCode.Z)) { Ability(); }
        else { piv.accelerate(1); }
    }
}
