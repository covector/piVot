using UnityEngine;

public class PivotEngine : MonoBehaviour
{
    // Pivot postition relative to parent position
    public Vector2 pivRelPar;
    // Object position relative to pivot position
    public Vector2 objRelPiv;

    // Initialize pivot location and object location relative to pivot
    public void Init(float pivRelParX = 0f, float pivRelParY = 0f, float objRelPivX = 0f, float objRelPivY = 0f)
    {
        pivRelPar = new Vector2(pivRelParX, pivRelParY);
        objRelPiv = new Vector2(objRelPivX, objRelPivY);
    }

    // Apply a rotational matrix on a vector
    private Vector2 RotVec(Vector2 pos, float angle)
    {
        float radAngle = angle * Mathf.Deg2Rad;
        float x = pos.x * Mathf.Cos(radAngle) + pos.y * -1 * Mathf.Sin(radAngle);
        float y = pos.x * Mathf.Sin(radAngle) + pos.y * Mathf.Cos(radAngle);
        return new Vector2(x, y);
    }

    // Calculate the object position relative to its parent
    private void EvalPos()
    {
        Vector2 rotatedObjRelPiv = RotVec(objRelPiv, transform.eulerAngles.z);
        transform.localPosition = rotatedObjRelPiv + pivRelPar;
    }

    // Rotate the object around its pivot
    public void Rotate(float angle)
    {
        transform.eulerAngles += new Vector3(0f, 0f, angle);
        EvalPos();
    }

    // Setting a new pivot without changing the object's position relative to its parent
    public void MovePiv(Vector2 pos)
    {
        pivRelPar = pos;
        objRelPiv = RotVec((Vector2)transform.localPosition - pivRelPar, -1 * transform.eulerAngles.z);
    }
}