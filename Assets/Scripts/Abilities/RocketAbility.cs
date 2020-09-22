using UnityEngine;

public class RocketAbility : MonoBehaviour
{
    public Pivot piv;
    private float fuel;
    public float fuelRate;
    private float Ability()
    {
        fuel -= fuelRate * Time.deltaTime;
        int ranOut = fuel <= 0 ? 1 : 0;
        piv.accelerate(ranOut);
        return fuel;
    }
    private void Update()
    {
        int limit = fuel >= 1 ? 1 : 0;
        fuel += Time.deltaTime * limit;
        
    }
}
