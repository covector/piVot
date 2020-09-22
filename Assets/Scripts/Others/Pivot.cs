using UnityEngine;

public class Pivot : MonoBehaviour
{
    #region Pivot Mechanism
    public Transform obj;
    public Vector2 pivotWorld;
    public Vector2 pivotLocal;
    public static float screenScale;
    public Vector2 truePos;
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
        truePos = (pivotWorld + offset);
        obj.position = truePos * screenScale;
    }
    public void translate(Vector2 vec, int delta, int world, int invar)
    {
        pivotWorld += world * (vec - (1-delta) * pivotWorld);
        pivotLocal += (1 - world) * (vec - (1 - delta) * pivotLocal);
        pivotLocal += invar * world * (rotMat(truePos - pivotWorld, -1 * obj.eulerAngles.z) - pivotLocal);
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
        Vector2 worldSpace = truePos + stickSpace * new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle));
        translate(worldSpace, 0, 1, 1);
    }
    public void togglePivot()
    {
        pivotLoc = 1 - pivotLoc;
        setStickPivot(pivotLoc);
    }
    #endregion

    #region Direction Control
    public int direction = 1;
    public void changeDir(int from, int wall)
    {
        int xLarge = truePos.x > pivotWorld.x ? 1 : 0;
        int yLarge = truePos.y > pivotWorld.y ? 1 : 0;
        int[] dir = new int[] { 1 - 2 * xLarge, 2 * yLarge - 1, 2 * xLarge -1, 1 - 2 * yLarge };
        direction = (pivotLoc == from) ? direction : dir[wall];
    }
    public void changeDir()
    {
        direction *= -1;
    }
    #endregion

    #region Special
    public Vector2 getLoc(float portion)
    {
        float stickSpace = 2 * stickLimit * (portion - 0.5f);
        float radAngle = obj.eulerAngles.z * Mathf.PI / 180;
        Vector2 worldSpace = truePos + stickSpace * new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle));
        return worldSpace * screenScale;
    }
    public float minSpeed;
    public float maxSpeed;
    private float currSpeed;
    public void accelerate(int dir)
    {
        currSpeed = minSpeed * dir + maxSpeed * (1 - dir);
    }
    #endregion
    private void Start()
    {
        currSpeed = minSpeed;
    }
    private void Update()
    {
        rotate(currSpeed * Time.deltaTime * direction, 1);
        if (Input.GetKeyDown(KeyCode.X)) { togglePivot(); }
    }
}
