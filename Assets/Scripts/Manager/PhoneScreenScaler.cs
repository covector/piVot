using UnityEngine;

public class PhoneScreenScaler : MonoBehaviour
{
    public Camera cam;
    public float initScale;
    public Vector2 topRight;
    public Transform screen;
    void Start()
    {
        Vector2 camTopRight = cam.ViewportToWorldPoint(new Vector2(initScale, initScale));
        float minSide = Mathf.Min(camTopRight.x, camTopRight.y);
        topRight = new Vector2(minSide, minSide);
        screen.localScale = topRight;
        Pivot.screenScale = minSide / 9f;
        Enemy.screenScale = minSide / 9f;
    }
    void Update()
    {
        Start();
    }
    public float getTopRight()
    {
        Vector2 camTopRight = cam.ViewportToWorldPoint(new Vector2(initScale, initScale));
        float minSide = Mathf.Min(camTopRight.x, camTopRight.y);
        return minSide;
    }
}
