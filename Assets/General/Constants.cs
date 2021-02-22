using UnityEngine;

[CreateAssetMenu(fileName = "Constants", menuName = "ScriptableObjects/ConstantsScriptableObject", order = 1)]
public class Constants : ScriptableObject
{
    public float areaRadius;
    public int coinCount;
    public float coinDiameter;
    public float pivObjDist;
    public float angularSpeed;
}
