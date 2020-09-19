using UnityEngine;

public class Pivot : MonoBehaviour
{
    #region Pivot Mechanism
    public Transform obj;
    public Vector2 pivotWorld;
    public Vector2 pivotLocal;
    private Vector2 rotMat(Vector2 pos, float angle)
    {
        float radAngle = angle * Mathf.PI / 180;
        float x = pos.x * Mathf.Cos(radAngle) + pos.y * -1 * Mathf.Sin(radAngle);
        float y = pos.x * Mathf.Sin(radAngle) + pos.y * Mathf.Cos(radAngle);
        return new Vector2(x, y);
    }
    private void evalPos()
    {
        Vector2 offset = rotMat(pivotLocal, obj.eulerAngles.z);
        obj.position = pivotWorld + offset;
    }
    public void translate(Vector2 vec, int delta, int world, int invar)
    {
        pivotWorld += world * (vec - (1-delta) * pivotWorld);
        pivotLocal += (1 - world) * (vec - (1 - delta) * pivotLocal);
        pivotLocal += invar * world * (rotMat((Vector2)obj.position - pivotWorld, -1 * obj.eulerAngles.z) - pivotLocal);
        evalPos();
    }
    public void rotate(float angle, int delta)
    {
        obj.eulerAngles += new Vector3(0f, 0f, (angle - (1-delta) * obj.eulerAngles.z));
        evalPos();
    }
    #endregion

    #region Player Control
    public float stickLimit;
    private int pivotLoc;
    public void setStickPivot(float portion)
    {
        float stickSpace = 2 * stickLimit * (portion-0.5f);
        float radAngle = obj.eulerAngles.z * Mathf.PI / 180;
        Vector2 worldSpace = (Vector2)obj.position + stickSpace * new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle));
        translate(worldSpace, 0, 1, 1);
    }
    public void togglePivot()
    {
        pivotLoc = 1 - pivotLoc;
        setStickPivot(pivotLoc);
    }
    #endregion

    private void Update()
    {
        //if (Input.GetKey(KeyCode.R)) { rotate(0.5f, 1); }
        rotate(240f*Time.deltaTime, 1);
        //if (Input.GetKeyDown(KeyCode.A)) { setStickPivot(0); }
        //if (Input.GetKeyDown(KeyCode.S)) { setStickPivot(0.333f); }
        //if (Input.GetKeyDown(KeyCode.D)) { setStickPivot(0.666f); }
        //if (Input.GetKeyDown(KeyCode.F)) { setStickPivot(1); }
        if (Input.GetKeyDown(KeyCode.X)) { togglePivot(); }
    }
}
