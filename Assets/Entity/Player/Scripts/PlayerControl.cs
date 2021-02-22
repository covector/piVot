using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    DataManager dataManager;
    PlayerBehaviour behaviour;
    Weapon weapon;

    void Start()
    {
        behaviour = GetComponent<PlayerBehaviour>();
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) { behaviour.TogglePivot(); }
        //if (Input.GetKeyDown(dataManager.toggleKey)) { behaviour.TogglePivot(); }
        //if (Input.GetKeyDown(dataManager.abilityKey)) { weapon.Activate(); }
    }
}